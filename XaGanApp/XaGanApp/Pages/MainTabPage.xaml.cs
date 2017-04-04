using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaGanApp.Object;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace XaGanApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabPage : TabbedPage
    {
        public MainTabPage(List<PostDetail> postData)
        {
            InitializeComponent();

            Children.Add(new ListViewPage_XemTin(postData));
            Children.Add(new ContentPage_UpTin());
            //Children.Add(new ListViewPage1());
        }
    }
}
