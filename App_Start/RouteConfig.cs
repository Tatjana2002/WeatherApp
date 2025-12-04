using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AplikacijaVremenskePrognoze
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ForecastForNext5Days",
               url: "Weather/ForecastForNext5Days/{city}",
               defaults: new { controller = "Weather", action = "ForecastForNext5Days", city = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "WeatherDetails",
                url: "Weather/WeatherDetails/{cityName}",
                defaults: new { controller = "Weather", action = "WeatherDetails" }
            );

            routes.MapRoute(
                name: "WeatherApi",
                url: "Weather/GetWeather/{city}",
                defaults: new { controller = "Weather", action = "GetWeather" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Weather", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
