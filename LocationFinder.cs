using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public class LocationFinder
    {
        public class Location
        {
            public Location(string latLng)
            {
                this.Lat = latLng.Split(",".ToCharArray())[0];
                this.Lng = latLng.Split(",".ToCharArray())[1];
            }

            public string Lat { get; set; }
            public string Lng { get; set; }
        }

        static HttpClient client = new HttpClient();
        
        public async Task<Location> FetchLocation()
        {
            string latLng = null;
            HttpResponseMessage response = await client.GetAsync($"https://ipapi.co/latlong").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                latLng = await response.Content.ReadAsStringAsync();
            }
            return new Location(latLng);
        }
    }
}
