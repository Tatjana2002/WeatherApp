using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplikacijaVremenskePrognoze.Models;
using AplikacijaVremenskePrognoze.Services;
using System.Globalization;
using System.Data.Entity;




namespace AplikacijaVremenskePrognoze.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather



        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService(); // Rucno instanciranje

        }


        public async Task<ActionResult> Index()
        {
            var cities = new List<string> { "Ankara", "Moscow", "London", "Berlin", "Madrid", "Kyiv", "Rome", "Paris", "Warsaw", "Barcelona", "Budapest", "Belgrade", "Prague", "Amsterdam", "Dublin", "Ljubljana", "Sarajevo", "Tirana", "Vienna", "Minsk", "Sofia", "Bern", "San Marino", "Oslo", "Brussels" };
            cities.Sort();
            var weatherList = new List<WeatherData>();


            foreach (var city in cities)
            {
                var weatherData = await _weatherService.GetWeatherAsync(city);
                if (weatherData != null)
                {
                    weatherList.Add(weatherData);
                }
            }

            return View("WeatherListView", weatherList);
        }


        public async Task<ActionResult> WeatherDetails(string cityName)
        {

            if (string.IsNullOrEmpty(cityName))
            {
                return RedirectToAction("Index");
            }

            var weatherData = await _weatherService.GetWeatherAsync(cityName);
            if (weatherData == null)
            {
                return HttpNotFound();
            }
            return View("WeatherDetailsView", weatherData);
        }

        public async Task<ActionResult> ForecastForNext5Days(string city)
        {


            var weatherData = await _weatherService.GetForecastAsync(city);

            if (weatherData == null || weatherData.List == null || !weatherData.List.Any())
            {
                return HttpNotFound("Podaci o vremenu nisu pronadjeni");
            }


            var dayTempList = new List<DayTemperature>();

            var groupedByDay = weatherData.List
                .GroupBy(item =>
                {
                    DateTime dateTime = DateTime.ParseExact(item.Dt_txt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    return dateTime.ToString("dddd", new CultureInfo("en-US")); // Grupisanje po danu u nedelji
                })
                .Take(5);


            foreach (var group in groupedByDay)
            {
                double avgTemperature = Math.Round(group.Average(item => item.Main.Temp), 2);


                var mostCommonIcon = group
                    .GroupBy(item => item.Weather[0].Icon)
                    .OrderByDescending(g => g.Count())//sortiramo opadajuce po broju elemenata, a count prebrojava koliko ih ima u grupi
                    .FirstOrDefault()?.Key;

                var mostCommonDescription = group
                    .GroupBy(item => item.Weather[0].Description)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault()?.Key;


                dayTempList.Add(new DayTemperature
                {
                    DayOfWeek = group.Key,
                    AvgTemperature = avgTemperature,
                    AvgIcon = mostCommonIcon,
                    Description = mostCommonDescription,
                });
            }
            ViewBag.CityName = weatherData.City.Name;

            return View("ForecastForNext5DaysView", dayTempList);
        }

        public async Task<ActionResult> DayDetails(string city, string dayOfWeek)
        {

            var weatherData = await _weatherService.GetForecastAsync(city);

            if (weatherData == null || weatherData.List == null || !weatherData.List.Any())
            {
                return HttpNotFound("Podaci o vremenu nisu pronadjeni");
            }
            var selectedDayForecast = weatherData.List
               .Where(item =>
               {
                   DateTime dateTime = DateTime.ParseExact(item.Dt_txt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                   return dateTime.ToString("dddd", new CultureInfo("en-US")) == dayOfWeek;
               })
               .ToList();

            if (!selectedDayForecast.Any())
            {
                return HttpNotFound("Nema podataka za izabrani dan.");
            }

            DateTime firstDate = DateTime.ParseExact(selectedDayForecast.First().Dt_txt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            ViewBag.FormattedDate = firstDate.ToString("dd. MMMM yyyy", new CultureInfo("en-US"));

            return PartialView("_DayDetails", selectedDayForecast);
        }




    }


}