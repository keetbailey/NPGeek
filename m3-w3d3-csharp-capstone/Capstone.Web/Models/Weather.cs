using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {

        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }


        public double CelsiusLow
        {
            get
            {
                double C = ((Low - 32) * (5.0 / 9.0));
                return C;
            }
        }

        public double CelsiusHigh
        {
            get
            {
                double C = ((High - 32) * (5.0 / 9.0));
                return C;
            }
        }

    }
}






