using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly SurveySQLDAL surveyDAL;

        public SurveyController()
        {
            surveyDAL = new SurveySQLDAL();
        }
        // GET: Survey
        public ActionResult Index()
        {
            return View();
        }
    }
}