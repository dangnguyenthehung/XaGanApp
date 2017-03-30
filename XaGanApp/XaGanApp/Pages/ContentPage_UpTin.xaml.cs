using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

            public ContentPage_UpTinViewModel()
            {
                Items = new ObservableCollection<Item>(new[]
                {
                new Item { Text = "Baboon", Detail = "Africa & Asia" },
                new Item { Text = "Capuchin Monkey", Detail = "Central & South America" },
                new Item { Text = "Blue Monkey", Detail = "Central & East Africa" },
                new Item { Text = "Squirrel Monkey", Detail = "Central & South America" },
                new Item { Text = "Golden Lion Tamarin", Detail= "Brazil" },
                new Item { Text = "Howler Monkey", Detail = "South America" },
                new Item { Text = "Japanese Macaque", Detail = "Japan" },
            });
                
            }

            


            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            public class Item
            {
                public string Text { get; set; }
                public string Detail { get; set; }

                public override string ToString() => Text;
            }

        }
    }
}
