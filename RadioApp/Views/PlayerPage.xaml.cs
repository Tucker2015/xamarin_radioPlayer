using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaManager;
using MediaManager.Library;
using Xamarin.Forms;

namespace RadioApp.Views
{
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage()
        {
            InitializeComponent();
            //SizeChanged += MainPageSizeChanged;

        }

        //void MainPageSizeChanged(object sender, EventArgs e)
        //{
        //    albumArt.WidthRequest = (App.screenWidth * 50) / 150;
        //    albumArt.HeightRequest = (App.screenHeight * 25) / 150;
        //    buttonSize.WidthRequest = (App.screenWidth * 50) / 300;
        //    buttonSize.HeightRequest = (App.screenHeight * 50) / 300;
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            volumeSlider.VolumeChanged += (sender, e) => Console.WriteLine($"Native slider volumne at {e.NewValue}");
        }

        
        private async Task InitPlay()
        {
            var currentMediaItem = await CrossMediaManager.Current.Play("https://streams.ktinternet.net:8012");
            CrossMediaManager.Current.Queue.Current.IsMetadataExtracted = false;
            Console.WriteLine($"Track {currentMediaItem.Artist}");
            currentMediaItem.DisplayTitle = currentMediaItem.Artist;
            currentMediaItem.DisplaySubtitle = currentMediaItem.Title;
            currentMediaItem.MetadataUpdated += (sender, args) => {
                    var title = args.MediaItem.DisplayTitle;
                };
            SetupCurrentMediaDetails(currentMediaItem);
            
        }

        private void SetupCurrentMediaDetails(IMediaItem currentMediaItem)
        {
            // Set up Media item details in UI
            var displayDetails = string.Empty;
            if (!string.IsNullOrEmpty(currentMediaItem.DisplayTitle))
                displayDetails = currentMediaItem.DisplayTitle;

            if (!string.IsNullOrEmpty(currentMediaItem.Artist))
                displayDetails = $"{displayDetails} - {currentMediaItem.Artist}";

            LabelMediaDetails.Text = displayDetails.ToUpper();
        }

        private async void PlayPauseButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMediaManager.Current.IsPrepared())
            {
                await InitPlay();
            }
            else
            {
                await CrossMediaManager.Current.PlayPause();
            }
        }
        
    }
}
