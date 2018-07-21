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
        public double C { get; set; }
        public double F { get; set; }

        public double CelsiusToFarenheit()
        {
            F = ((C * 9 / 5) + 32);
            return F;
        }

        public double FarenheitToCelsius()
        {
            C = ((F - 32) * (5 / 9));
            return C;
        }

        public static List<SelectListItem> Parks
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Cuyahoga Valley National Park", Value = "CVNP" },
                    new SelectListItem { Text = "Everglades National Park", Value = "ENP" },
                    new SelectListItem { Text = "Grand Canyon National Park", Value = "GCNP" },
                    new SelectListItem { Text = "Glacier National Park", Value = "GNP" },
                    new SelectListItem { Text = "Great Smokey Mountains National Park", Value = "GSMNP" },
                    new SelectListItem { Text = "Grand Teton National Park", Value = "GTNP" },
                    new SelectListItem { Text = "Mount Ranier National Park", Value = "MRNP" },
                    new SelectListItem { Text = "Rocky Mountain National Park", Value = "RMNP" },
                    new SelectListItem { Text = "Yellowstone National Park", Value = "YNP" },
                    new SelectListItem { Text = "Yosemite National Park", Value = "YNP2" },

                };
            }
        }
    }
}






