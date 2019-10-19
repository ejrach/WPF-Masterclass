using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Model
{
    //These defintions were defined with the help of copying and pasting a JSON response from Accuweather into
    //JSON utils (from the internet: https://jsonutils.com/) and then slightly modifiying.

    public class Area
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

    public class City
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public Area Country { get; set; }
        public Area AdministrativeArea { get; set; }
    }
}
