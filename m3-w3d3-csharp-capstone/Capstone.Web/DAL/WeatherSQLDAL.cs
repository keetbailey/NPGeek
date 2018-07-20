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

        public List<Weather> GetWeather()
        {
            List<Weather> WeatherResults = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SqlGetWeather);
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Weather weather = new Weather();
                        weather.ParkCode = Convert.ToString(reader["parCode"]);
                        weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        weather.Low = Convert.ToInt32(reader["low"]);
                        weather.High = Convert.ToInt32(reader["high"]);
                        weather.Forecast = Convert.ToString(reader["forecast"]);

                        WeatherResults.Add(weather);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return WeatherResults;
        }
    }
}