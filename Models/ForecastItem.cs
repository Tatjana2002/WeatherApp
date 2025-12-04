using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplikacijaVremenskePrognoze.Models
{
    public class ForecastItem
    {
        public long Dt { get; set; }
        public MainWeather Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Sys Sys { get; set; }
        public string Dt_txt { get; set; }
    }
}