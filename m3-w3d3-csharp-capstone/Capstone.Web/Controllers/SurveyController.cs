using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveySqlDAL surveyDAL;

        public SurveyController()
        {
            surveyDAL = new SurveySQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);
        }
        //GET: Survey
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ActionResult Confirmation()
        {
            IList<SurveyResult> surveyResult = surveyDAL.GetSurveyResults();

            return View("Confirmation", surveyResult);
        }
        [HttpPost]
        public ActionResult Index(SurveyResult createSurvey)
        {
            surveyDAL.CreateSurvey(createSurvey);

            return RedirectToAction("Confirmation", "Survey");
        }
    }
}