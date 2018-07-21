using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySQLDAL : ISurveySqlDAL
    {
        private readonly string connectionString;
        private const string sqlSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)" + "VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
        private const string sqlGetSurveyResults = "SELECT * FROM survey_result";

        public SurveySQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool CreateSurvey(SurveyResult survey)
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

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public IList<SurveyResult> GetSurveyResults()
        {
            IList<SurveyResult> surveys = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetSurveyResults);
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult survey = new SurveyResult();
                        survey.SurveyID = Convert.ToInt32(reader["surveyId"]);
                        survey.ParkCode = Convert.ToString(reader["parkCode"]);
                        survey.EmailAddress = Convert.ToString(reader["emailAddress"]);
                        survey.State = Convert.ToString(reader["state"]);
                        survey.ActivityLevel = Convert.ToString(reader["activityLevel"]);

                        surveys.Add(survey);

                    }
                    return surveys;

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

        }
    }
}

