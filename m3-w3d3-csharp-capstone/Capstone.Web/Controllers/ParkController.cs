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

        private readonly ParkSQLDAL parkDetail;
=======
       
>>>>>>> 2a69bad90bd81b12d968562c2f75f9681199ec5e

        public ParkController()
        {
            parkDAL = new ParkSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);

        }

        // GET: Home
        public ActionResult Index()
        {
            IList<Park> allParks = parkDAL.GetAllParks();

            return View("Index", allParks);
        }

        public ActionResult ParkDetail(string id)   
        {
            //create new park instance 
            Park newPark = parkDAL.ParkDetail(id);

            //assign park from database to new park 
            //return the View with actionresult method and new park instance 

            return View("ParkDetail", newPark);
        }
    }
}
