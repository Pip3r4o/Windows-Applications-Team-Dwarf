using JustQuest.UI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JustQuest.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddQuest : Page
    {
        public AddQuest()
        {
            this.InitializeComponent();
            myMap.Loaded += MyMap_Loaded;
            myMap.MapTapped += MyMap_MapTapped;
        }

        private async void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            Geoposition pos = await geolocator.GetGeopositionAsync();
            Geopoint myLocation = pos.Coordinate.Point;

            // Set the map location.
            myMap.Center = myLocation;
            myMap.ZoomLevel = 12;
            myMap.LandmarksVisible = true;

        }

        private void MyMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            var tappedGeoPosition = args.Location.Position;
            string status = "MapTapped at \nLatitude:" + tappedGeoPosition.Latitude + "\nLongitude: " + tappedGeoPosition.Longitude;
            NotifyUser(status, NotifyType.StatusMessage);
        }

        public void NotifyUser(string strMessage, NotifyType type)
        {
            switch (type)
            {
                case NotifyType.StatusMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                case NotifyType.ErrorMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;
            }
            StatusBlock.Text = strMessage;

            // Collapse the StatusBlock if it has no text to conserve real estate.
            StatusBorder.Visibility = (StatusBlock.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
            if (StatusBlock.Text != String.Empty)
            {
                StatusBorder.Visibility = Visibility.Visible;
                StatusPanel.Visibility = Visibility.Visible;
            }
            else
            {
                StatusBorder.Visibility = Visibility.Collapsed;
                StatusPanel.Visibility = Visibility.Collapsed;
            }
        }
        public enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteData.InitAsync();
            var userCredentials = SQLiteData.GetUserCredentials();
            using (var client = new HttpClient())
            {
                var token = "";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var formContent = new Dictionary<string, string>
                            {
                                {"Name", Name.Text },
                                {"Task", Task.Text },
                                {"PossibleAnswers", PossibleAnswers.Text }
                            };
                var content = new FormUrlEncodedContent(formContent);

                var response = await client.PostAsync("http://localhost:17888/api/Quests", content);

                var isSuccessfulRequest = response.IsSuccessStatusCode;

                if (!isSuccessfulRequest)
                {
                    //registerResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
