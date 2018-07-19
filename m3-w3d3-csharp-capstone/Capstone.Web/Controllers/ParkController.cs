using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;
//using Capstone.Web.DAL.Interfaces; 

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        //private IParkSqlDAL;

        //public ParkController(IParkSqlDAL dal)
        //{
        //    this.dal = dal;
        //}


        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

    }
}