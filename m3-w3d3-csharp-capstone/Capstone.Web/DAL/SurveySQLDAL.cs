using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySQLDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["NPGeekDatabase"].ConnectionString;
        private const string sqlSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)" + "VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
        private const string sqlGetSurveyResults = "SELECT surveyId, parkCode, emailAddress, state, activityLevel FROM survey_result";

        public SurveySQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void CreateSurvey(SurveyResult survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        //private Park MapRowToPark(SqlDataReader reader)  // possbly not necessary....

        //{
        //    return new Park()
        //    {
        //        ParkName = Convert.ToString(reader["parkName"]),
        //        State = Convert.ToString(reader["state"]),
        //        ParkDescription = Convert.ToString(reader["parkDescription"])
        //    };

        //}
    }
}

