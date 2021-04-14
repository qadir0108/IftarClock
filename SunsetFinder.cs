using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static DigitalClock.LocationFinder;
using System.Net;
using System.Net.Http.Headers;

namespace DigitalClock
{
    public class SunsetFinder
    {
        static HttpClient client = new HttpClient();
        
        public async Task<SunSet> FetchSunset(Location location)
        {
            string sunset = null;
            HttpResponseMessage response = await client.GetAsync($"http://api.sunrise-sunset.org/json?lat={location.Lat}&lng={location.Lng}&date=today&formatted=0").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                sunset = await response.Content.ReadAsStringAsync();
            }
            return JSONSerializer<SunSet>.DeSerialize(sunset);
        }
    }
}
