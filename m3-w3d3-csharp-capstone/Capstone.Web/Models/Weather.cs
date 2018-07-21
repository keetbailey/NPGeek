﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode {get; set;}
        public int FiveDayForecastValue {get; set;}
        public int Low {get; set;}
        public int High {get; set;}
        public string Forecast {get; set;}
        public int CelsiusToFarenheit {get; set;}
        public int FarenheitToCelsius {get; set;}

        

    }

}