using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RadioApp.Views
{
    public partial class FacebookPage : ContentPage
    {
        public FacebookPage()
        {
            InitializeComponent();
            webview.Source = "https://peoplescityradio.co.uk";
        }
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (webview.CanGoBack)
            {
                webview.GoBack();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
        void OnForwardButtonClicked(object sender, EventArgs e)
        {
            if (webview.CanGoForward)
            {
                webview.GoForward();
            }
        }

    }
}
