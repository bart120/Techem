using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Techem.Models;

namespace Techem.Services
{
    public static class WeatherService
    {
        const string url = "http://api.openweathermap.org/data/2.5/weather?";
        const string key = "3d13d25c0c34fa3c3db183ad6b8cdff4";

        public static async Task<Weather> GetWeatherByCity(string city)
        {
            string uri = $"{url}q={city}&appid={key}&units=metric";
            return await GetDataAsync(uri);
        }

        public static async Task<Weather> GetWeatherByGeoloc(double lon, double lat)
        {
            string uri = $"{url}lon={lon.ToString()}&lat={lat.ToString()}&appid={key}&units=metric";
            return await GetDataAsync(uri);
        }

        private async static Task<Weather> GetDataAsync(string url)
        {
            var result = await ApiService.GetDataFromServiceAsync(url).ConfigureAwait(false);
            if(result != null)
            {
                var weather = new Weather();

                weather.City = result["name"];
                weather.Temperature = Convert.ToDouble(result["main"]["temp"].ToString());
                weather.Icon = result["weather"][0]["icon"].ToString();

                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
                weather.Sun.Sunrise = dt.AddSeconds((double)result["sys"]["sunrise"]).AddHours(2);
                weather.Sun.Sunset = dt.AddSeconds((double)result["sys"]["sunset"]).AddHours(2);
                return weather;
            }
            return null;
        }
    }
}
