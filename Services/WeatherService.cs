using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AplikacijaVremenskePrognoze.Models;



namespace AplikacijaVremenskePrognoze.Services
{
    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey = "261a1b6fc5b3a45ad4dce9587311b393";
        private readonly string weatherUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric";
        private readonly string forecastForNext5DaysUrl = "https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric";


        public async Task<WeatherData> GetWeatherAsync(string city)
        {


            string url = string.Format(weatherUrl, city, apiKey);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Status code: {response.StatusCode}");

            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"JSON response: {json}");

            var weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
            return weatherData;
        }


        public async Task<ForecastData> GetForecastAsync(string city)
        {
            string url = string.Format(forecastForNext5DaysUrl, city, apiKey);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Status code: {response.StatusCode}");
        
            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"JSON response: {json}");

            var forecastData = JsonConvert.DeserializeObject<ForecastData>(json);
            return forecastData;



        }
    }
}