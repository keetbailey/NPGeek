using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using Capstone.Web.DAL;



namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        public WeatherController()
        {
            WeatherDAL = new WeatherSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);
        }
        
        
        // GET: Weather
        public ActionResult Index()
        {
            List<Weather> FiveDayWeather = WeatherDAL ();

            return View("Index", );
        }









    }
}