using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplikacijaVremenskePrognoze.Models
{
    public class ForecastData
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<ForecastItem> List { get; set; }
        public City City { get; set; }
        

    }
}