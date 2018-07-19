using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSQLDAL : IParkSqlDAL
    {
        private readonly string connectionString;
        private const string sqlPark = "select parkName, state, parkDescription FROM park";

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
    }
}





