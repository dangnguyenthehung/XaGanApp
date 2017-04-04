using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaGanApp.Code;
using XaGanApp.Object;
using Xamarin.Forms;

namespace XaGanApp
{
    public partial class App : Application
    {
        public static List<PostDetail> postData;

        public App()
        {
            InitializeComponent();

            MainPage = new Pages.MainTabPage(postData);
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
            base.OnStart ();
            postData = await GetData();
            MainPage = new Pages.MainTabPage(postData);
        }

        private async Task<List<PostDetail>> GetData()
        {
            return await GetPost.Get_All_Post();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
