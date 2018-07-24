using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public interface IWeatherSqlDAL
    {
        IList<Weather> GetWeather(string id);
    }
}