using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSQLDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["NPGeekDatabase"].ConnectionString;
        private const string SqlGetWeather = "SELECT parkCode, fiveDayForecastValue, low, high, forecast FROM weather";


    }
}