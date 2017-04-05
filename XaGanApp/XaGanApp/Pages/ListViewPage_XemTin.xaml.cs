using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XaGanApp.Code;
using XaGanApp.Object;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XaGanApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage_XemTin : ContentPage
    {
        List<PostDetail> list { get; set; }
        public ObservableCollection<PostDetail> ItemList { get; set; }


        public ListViewPage_XemTin(List<PostDetail> list)
        {
            InitializeComponent();
            //BindingContext = new ListViewPage_XemTinViewModel();


            // Do stuff in here
            //list = await GetPost.Get_All_Post();

            //ItemList = new ObservableCollection<PostDetail>();
            //postData;
            ItemList = new ObservableCollection<PostDetail>();
            if (list == null)
            {
                ItemList.Add(new PostDetail()
                {
                    post_type = "Waiting....",
                    post_address = "Loading data..."
                });
            }
            else
            {
                foreach (var item in list)
                {
                    ItemList.Add(item);
                }
            }
            BindingContext = new ListViewPage_XemTinViewModel(ItemList);


        }

        //private async void GetData()
        //{
        //    list = await GetPost.Get_All_Post();
        //    ItemList = new ObservableCollection<PostDetail>();
        //}

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }



    class ListViewPage_XemTinViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PostDetail> Items { get; set; }

        //public ObservableCollection<Grouping<string, Item>> ItemsGrouped { get; }

        public ListViewPage_XemTinViewModel()
        {
            Items = new ObservableCollection<PostDetail>();
            Items.Add(new PostDetail()
            {
                post_type = "Waiting....",
                post_address = "Loading data..."
            });
        }
        public ListViewPage_XemTinViewModel(ObservableCollection<PostDetail> Itemlist)
        {
            Items = new ObservableCollection<PostDetail>();
            Items = Itemlist;
            

            RefreshDataCommand = new Command(
                async () => await RefreshData());
        }
        

        public ICommand RefreshDataCommand { get; }

        async Task RefreshData()
        {
            IsBusy = true;
            //Load Data Here

            await Task.Delay(2000);

            IsBusy = false;
        }

        bool busy;
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
                ((Command)RefreshDataCommand).ChangeCanExecute();
            }
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

        //public class Grouping<K, T> : ObservableCollection<T>
        //{
        //    public K Key { get; private set; }

        //    public Grouping(K key, IEnumerable<T> items)
        //    {
        //        Key = key;
        //        foreach (var item in items)
        //            this.Items.Add(item);
        //    }
        //}
    }
}
