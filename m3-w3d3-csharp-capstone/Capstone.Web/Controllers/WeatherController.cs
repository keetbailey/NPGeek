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
        private readonly IWeatherSqlDAL weatherDAL;

        public WeatherController()
        {
            weatherDAL = new WeatherSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);
        }



        // GET: Weather
        public ActionResult Index(string id)
        {
            IList<Weather> fiveDayWeather = weatherDAL.GetWeather(id);

            return View("Weather", fiveDayWeather);
        }

        // Change Temeraure Scale 
        [HttpPost]
        public ActionResult ChangeTemperatureScale(string id)
        {
            if (Session["isFarenheit"] == null)
            {
                Session["isFarenheit"] = true;
            }

            Session["isFarenheit"] = !(bool)(Session["isFarenheit"]);

            return RedirectToAction("Index", new { id = id });
        }

    }
}









    