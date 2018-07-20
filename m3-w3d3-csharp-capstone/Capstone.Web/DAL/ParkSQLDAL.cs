using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSQLDAL : IParkSqlDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString;
        private const string sqlPark = "SELECT parkName, state, parkDescription FROM park";
        private const string parkDetailSql = "SELECT parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies FROM park";

        public ParkSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlPark, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();

                        park.ParkName = Convert.ToString(reader["parkName"]);  
                        park.State = Convert.ToString(reader["state"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);

                        parks.Add(park);
                    }
                }
                return parks;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
     
        public List<Park> ParkDetail()
        {
            List<Park> parkDetail = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(parkDetailSql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park parkDetails = new Park();

                        parkDetails.ParkName = Convert.ToString(reader["parkName"]);
                        parkDetails.State = Convert.ToString(reader["state"]);
                        parkDetails.Acreage = Convert.ToInt32(reader["acreage"]);
                        parkDetails.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        parkDetails.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        parkDetails.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        parkDetails.Climate = Convert.ToString(reader["climate"]);
                        parkDetails.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        parkDetails.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        parkDetails.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        parkDetails.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        parkDetails.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        parkDetails.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        parkDetails.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        parkDetail.Add(parkDetails);
                    }
                }
                return parkDetail;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
