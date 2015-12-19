using JustQuest.UI.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    using DataModels.QuestDataModels;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddHint : Page
    {
        public AddHint()
        {
            this.InitializeComponent();

            var contentViewModel = new QuestViewModel();
            this.DataContext = new AddQuestViewModel(contentViewModel);

            myMap.Loaded += MyMap_Loaded;
            myMap.MapTapped += MyMap_MapTapped;
        }

        private async void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                Geolocator geolocator = new Geolocator();
                Geoposition pos = await geolocator.GetGeopositionAsync();
                Geopoint myLocation = pos.Coordinate.Point;

                // Set the map location.
                myMap.Center = myLocation;
                myMap.ZoomLevel = 12;
                myMap.LandmarksVisible = true;
            }
            else
            {
                await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
            }
        }

        private void MyMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            var tappedGeoPosition = args.Location.Position;
            LongitudeBox.Text = tappedGeoPosition.Longitude.ToString();
            LatitudeBox.Text = tappedGeoPosition.Latitude.ToString();
            
        }
    }
}
