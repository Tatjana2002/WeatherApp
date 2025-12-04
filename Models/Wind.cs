using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplikacijaVremenskePrognoze.Models
{
    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double? Gust { get; set; }
    }
}