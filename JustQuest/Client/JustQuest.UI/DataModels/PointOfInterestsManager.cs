using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace JustQuest.UI.DataModels
{
    public class PointOfInterestsManager
    {
        public List<PointOfInterest> FetchPOIs(BasicGeoposition center)
        {
            List<PointOfInterest> pois = new List<PointOfInterest>();
            pois.Add(new PointOfInterest()
            {
                DisplayName = "Search inder the blue door",
                ImageSourceUri = new Uri("ms-appx:///Assets/MapPin.png", UriKind.RelativeOrAbsolute),
                Location = new Geopoint(new BasicGeoposition()
                {

                    Latitude = center.Latitude + 0.001,
                    Longitude = center.Longitude - 0.001
                })
            });
            return pois;
        }
    }
}
