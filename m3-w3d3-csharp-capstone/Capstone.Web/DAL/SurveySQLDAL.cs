using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySQLDAL
    {
        private readonly string connectionString;
        private const string sqlSurvey = "INSERT INTO survey_result (surveyId, parkCode, emailAddress, state, activityLevel) VALUES (@surveyId, @parkCode, @emailAddress, @state, @activityLevel)";
        private const string sqlSurveyResults = "SELECT surveyId, parkCode, emailAddress, state, activityLevel FROM survey_result"; 

        public SurveySQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IList<SurveyResult> GetAllParks()
        {
            IList<SurveyResult> surveys = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlSurvey, conn);
                          SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult survey = new SurveyResult();
                        {
                            survey.SurveyID  = Convert.ToString(reader["surveyId"]);
                            survey.ParkCode = Convert.ToString(reader["parkCode"]);
                            survey.EmailAddress = Convert.ToString(reader["emailAddress"]);
                            survey.State = Convert.ToString(reader["state"]);
                            survey.ActivityLevel = Convert.ToString(reader["activityLevel"]);

                        }
                        surveys.Add(survey);

                        //using (SqlConnection conn = new SqlConnection(connectionString))
                        //{
                        //    conn.Open();

                        //    SqlCommand cmd = new SqlCommand(SQL, conn);

                        //    cmd.Parameters.AddWithValue("@site_id", newReservation.SiteId);
                        //    cmd.Parameters.AddWithValue("@name", newReservation.Name);
                        //    cmd.Parameters.AddWithValue("@from_date", newReservation.FromDate);
                        //    cmd.Parameters.AddWithValue("@to_date", newReservation.ToDate);

                        //    cmd.ExecuteNonQuery();


                        //}

                    }
                }
                return surveys;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}