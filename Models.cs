using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    [DataContract]
    public partial class SunSet
    {
        [DataMember]
        public Results results { get; set; }

        public string status { get; set; }
    }

    [DataContract]
    public partial class Results
    {
        [DataMember]
        public string sunrise { get; set; }

        [DataMember]
        public string sunset { get; set; }

        public string solar_noon { get; set; }

        public long day_length { get; set; }

        public string civil_twilight_begin { get; set; }

        [DataMember]
        public string civil_twilight_end { get; set; }

        [DataMember]
        public string nautical_twilight_begin { get; set; }

        public string nautical_twilight_end { get; set; }

        public string astronomical_twilight_begin { get; set; }

        public string astronomical_twilight_end { get; set; }
    }
}
