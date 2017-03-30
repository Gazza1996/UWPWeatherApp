using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace UWPWeatherApp
{
    public class Location
    {
        public async static Task<Geoposition> position()
        {
            // code to gather Exact GPS Location (Currently not in use)
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();
            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            var location = await geolocator.GetGeopositionAsync();


            return location;
        }
    }
}
