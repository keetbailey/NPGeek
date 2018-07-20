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
    public class ParkController : Controller
    {
        private readonly IParkSqlDAL parkDAL;
<<<<<<< HEAD

        public ParkController()
        {
            parkDAL = new ParkSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);
=======
        private readonly ParkSQLDAL parkDetail;

        public ParkController()
        {
            parkDAL = new ParkSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);

            parkDetail = new ParkSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);
>>>>>>> d3c6fd159c2058333a8bc630d3861e9e9aaae2ee
        }

        // GET: Home
        public ActionResult Index()
        {
            IList<Park> allParks = parkDAL.GetAllParks();

            return View("Index", allParks);
<<<<<<< HEAD
=======
        }

        public ActionResult ParkDetail()
        {
            List<Park> parkDetails = parkDetail.ParkDetail();

            return View("ParkDetail", parkDetails);
>>>>>>> d3c6fd159c2058333a8bc630d3861e9e9aaae2ee
        }

    }
}