using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplikacijaVremenskePrognoze.Models
{
    public class DayTemperature
    {
        public string DayOfWeek { get; set; }
        public double AvgTemperature { get; set; }
        public string AvgIcon { get; set; }
        public string Description { get; set; }
        public List<ForecastItem> ForecastItemList { get; set; }
       
        
    }
}