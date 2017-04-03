using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XaGanApp.Code;
using XaGanApp.Interfaces;
using XaGanApp.Object;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XaGanApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentPage_UpTin : ContentPage
    {
        Dictionary<string, string> typeList = new Dictionary<string, string>
                {
                    {"Thuê văn phòng", "Thuê văn phòng" },
                    {"Thuê nhà", "Thuê nhà" },
                    {"Thuê mặt bằng", "Thuê mặt bằng" },
                    {"Thuê phòng", "Thuê phòng" }
                };
        PostDetails model = new PostDetails();

        public ContentPage_UpTin()
        {
            InitializeComponent();
            BindingContext = new ContentPage_UpTinViewModel();

            foreach (var item in typeList.Keys)
            {
                Input_Type.Items.Add(item);
            }
            Input_Type.SelectedIndex = 0;
        }

        public class ContentPage_UpTinViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Item> Items { get; }
            public PostDetail postInfo { get; set; }

            public ContentPage_UpTinViewModel()
            {
                //    Items = new ObservableCollection<Item>(new[]
                //    {
                //    new Item { Text = "Baboon", Detail = "Africa & Asia" },
                //    new Item { Text = "Capuchin Monkey", Detail = "Central & South America" },
                //    new Item { Text = "Blue Monkey", Detail = "Central & East Africa" },
                //    new Item { Text = "Squirrel Monkey", Detail = "Central & South America" },
                //    new Item { Text = "Golden Lion Tamarin", Detail= "Brazil" },
                //    new Item { Text = "Howler Monkey", Detail = "South America" },
                //    new Item { Text = "Japanese Macaque", Detail = "Japan" },
                //});

                Items = new ObservableCollection<Item>();

            }

           
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //public class Item
            //{
            //    public string Text { get; set; }
            //    public string Detail { get; set; }

            //    public override string ToString() => Text;
            //}
            public class Item
            {
                //public string Image { get; set; }
                public string ImageUrl { get; set; }

                public override string ToString() => ImageUrl;
            }

        }

        //    picker.SelectedIndexChanged += (sender, args) =>
        //            {
        //                if (picker.SelectedIndex == -1)
        //                {
        //                    boxView.Color = Color.Default;
        //                }
        //                else
        //                {
        //                    string colorName = picker.Items[picker.SelectedIndex];
        //boxView.Color = nameToColor[colorName];
        //                }
        //            };


        private async void btn_post_upload(object sender, EventArgs e)
        {
            btn.Text = "Đang xử lý....";
            btn.IsEnabled = false;

            model.post_type = Input_Type.Items[Input_Type.SelectedIndex];
            model.post_email = Input_Mail.Text.ToString();
            model.post_phoneNumber = long.Parse(Input_Phone.Text.ToString());
            model.post_address = Input_Address.Text.ToString();
            model.post_square = double.Parse(Input_Square.Text.ToString());
            model.post_price = double.Parse(Input_Price.Text.ToString());
            model.post_additonalInfo = Input_Details.Text.ToString();

            await Upload_Images(); // upload images and get img url


            btn.Text = "Xong";
            clearText();
            await Task.Delay(2000);
            btn.IsEnabled = true;

            btn.Text = "Đăng tin";

        }

        private async void PickPhoto_Clicked(object sender, EventArgs e)
        {
            //GridView.Children.Clear();
            //pathListContain.Children.Clear();
            //_mediaFile = null;

            var click = DependencyService.Get<IPhotoPicker>();
            if (click != null)
            {
                var pathList = await click.openBtn_Click();

                var col = 0;
                var row = 0;
                foreach (var item in pathList)
                {
                    if (col == 6)
                    {
                        break;
                    }

                    //ImageContain.Children.Add(new Image()
                    //{
                    //    Source = ImageSource.FromFile(item),
                    //    HorizontalOptions = LayoutOptions.Center,
                    //    VerticalOptions = LayoutOptions.Center

                    //}, col, row);

                    ImageContain.Children.Add(new Frame
                    {
                        Content = new Image()
                        {
                            Source = ImageSource.FromFile(item),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center
                        },
                        OutlineColor = Color.Black,
                        Padding = 1,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.Center
                    }, col, row);

                    col++;

                }
            }
        }

        private async Task Upload_Images()
        {
            //GridView.Children.Clear();
            //pathListContain.Children.Clear();
            //if (_mediaFile == null)
            //{
            var action = DependencyService.Get<IPhotoPicker>();
            if (action != null)
            {
                List<string> responseList = await action.Upload(); // get list image url after upload
                List<string> urlList = new List<string>();
                foreach (var item in responseList)
                {

                    string itemUrl = formatUrl(item);

                    System.Diagnostics.Debug.WriteLine(itemUrl);

                    urlList.Add(itemUrl);
                }
                model.post_images = urlList;
                SendRequest.Upload_Post(model);
            }
            else
            {
                //
            }
            //}
        }

        private string formatUrl(string originalUrl)
        {
            int startIndex = originalUrl.IndexOf("www");
            originalUrl = originalUrl.Substring(startIndex, originalUrl.Length - startIndex - 1).Replace("\\", "/").Replace("//", "/");
            string newUrl = "http://" + originalUrl;

            return newUrl;
        }

        private void clearText()
        {
            Input_Type.SelectedIndex = 0;
            Input_Mail.Text = "";
            Input_Phone.Text = "";
            Input_Address.Text = "";
            Input_Square.Text = "";
            Input_Price.Text = "";
            Input_Details.Text = "";
            ImageContain.Children.Clear();
        }
    }
}
