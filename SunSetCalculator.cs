using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalClock
{
    public class SunSetCalculator
    {
        DateTime sunset = DateTime.MinValue;// = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 52, 0);
        Dictionary<string, string> sunsets = new Dictionary<string, string>();
        readonly string dataFile = System.IO.Path.GetTempPath() + "IftarClock.bin";
        public TimeSpan GetRemainingTime()
        {
            return sunset - DateTime.Now;
        }

        public bool IsSunSetAlreadyGot()
        {
            Read();
            var IsSunSetGot = sunsets.Any(x => x.Key == DateTime.Now.DayOfYear + "");
            if (IsSunSetGot)
                sunset = sunsets.FirstOrDefault(x => x.Key == DateTime.Now.DayOfYear + "").Value.FromDataFormat();

            return IsSunSetGot;
        }

        public void FetchAndSaveSunSet()
        {
            if(!IsSunSetAlreadyGot())
            {
                var location = new LocationFinder()
                        .FetchLocation().Result;

                var sunsetToday = new SunsetFinder()
                                .FetchSunset(location).Result;

                sunsets.Add(
                    DateTime.Now.DayOfYear + "",
                    sunsetToday.results.sunset.ToIsoFormat().ToLocalTime().ToDataFormat());
                Write();

                sunset = sunsets.FirstOrDefault(x => x.Key == DateTime.Now.DayOfYear + "").Value.FromDataFormat();
            }
        }

        private void Read()
        {
            sunsets.Clear();
            if (!File.Exists(dataFile)) File.Create(dataFile).Close();
            foreach(var sunset in File.ReadLines(dataFile)) 
            {
                sunsets.Add(sunset.Split(":".ToCharArray())[0], sunset.Split(":".ToCharArray())[1]);
            }
        }

        private void Write()
        {
            using (StreamWriter file = new StreamWriter(dataFile))
            {
                foreach (var sunset in sunsets)
                {
                    file.WriteLine("{0}:{1}", sunset.Key, sunset.Value);
                }
            }
        }
    }
}
