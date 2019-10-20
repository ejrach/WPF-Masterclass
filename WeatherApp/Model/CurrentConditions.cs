using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Model
{
    //These defintions were defined with the help of copying and pasting a JSON response from Accuweather into
    //JSON utils (from the internet: https://jsonutils.com/) and then slightly modifiying.
    public class Units
    {
        public string Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Units Metric { get; set; }
        public Units Imperial { get; set; }
    }

    public class CurrentConditions
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}
