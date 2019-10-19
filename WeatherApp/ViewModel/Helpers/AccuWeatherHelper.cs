using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        //These formatted strings come from the AccuWeather site by calling an endpoint. Then go to the cURL tab.
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "VR6RQJHS4O16LujfdPYFG2ouCYjwaYUS";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using (HttpClient client = new HttpClient())
            {
                //Get the response from the HTTP request
                var response = await client.GetAsync(url);

                //read the json string
                string json = await response.Content.ReadAsStringAsync();

                //Now need to deserialize the json string
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions (string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                //Get the response from the HTTP request
                var response = await client.GetAsync(url);

                //read the json string
                string json = await response.Content.ReadAsStringAsync();

                //Now need to deserialize the json string
                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
