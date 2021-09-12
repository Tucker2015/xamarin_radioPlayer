using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RadioApp.Services;
using RadioApp.Views;
using MediaManager;

namespace RadioApp
{
    public partial class App : Application
    {
        public static int screenWidth;
        public static int screenHeight;

        public App()
        {
            InitializeComponent();
            CrossMediaManager.Current.Init();
            MainPage = new AppShell();
        }

       

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
