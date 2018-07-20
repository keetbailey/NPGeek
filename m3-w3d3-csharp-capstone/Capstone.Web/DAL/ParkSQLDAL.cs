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
<<<<<<< HEAD
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString;
        private const string sqlPark = "SELECT parkName, state, parkDescription FROM park";
        private const string parkDetailSql = "SELECT parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies FROM park";
=======
        private readonly string connectionString;
        private const string sqlPark = "SELECT * FROM park";
        private const string parkDetailSql = "SELECT * from park WHERE parkCode = @parkCode";
>>>>>>> 2a69bad90bd81b12d968562c2f75f9681199ec5e

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
<<<<<<< HEAD
                        Park park = new Park();

                        park.ParkName = Convert.ToString(reader["parkName"]);  
                        park.State = Convert.ToString(reader["state"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
=======
                        Park park = MapRowToPark(reader);
>>>>>>> 2a69bad90bd81b12d968562c2f75f9681199ec5e

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
<<<<<<< HEAD
     
        public List<Park> ParkDetail()
=======
        public Park ParkDetail(string parkCode)
>>>>>>> 2a69bad90bd81b12d968562c2f75f9681199ec5e
        {
            Park parkDetail = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(parkDetailSql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode); ///look into SQL profiler - lets you see behind the scenes - will trace the session to show you all queries running against your database 

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        parkDetail = MapRowToPark(reader);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return parkDetail;
        }

        private Park MapRowToPark(SqlDataReader reader)

        {
            return new Park()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                
            };

        }
    }
}
