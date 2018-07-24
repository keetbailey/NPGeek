using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSQLDAL : IWeatherSqlDAL

     {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString;
        private const string SqlGetWeather = "SELECT parkCode, fiveDayForecastValue, low, high, forecast FROM weather WHERE parkCode = @parkCode";

        public WeatherSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public IList<Weather> GetWeather(string id)
        {
            IList<Weather> WeatherResults = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SqlGetWeather);
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@parkCode", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Weather weather = new Weather();
                        weather.ParkCode = Convert.ToString(reader["parkCode"]);
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