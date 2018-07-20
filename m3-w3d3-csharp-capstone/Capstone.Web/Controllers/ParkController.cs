﻿using System;
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

        private readonly ParkSQLDAL parkDetail;

        public ParkController()
        {
            parkDAL = new ParkSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);

            parkDetail = new ParkSQLDAL(ConfigurationManager.ConnectionStrings["NPGeekConnectionString"].ConnectionString);
        }

        // GET: Home
        public ActionResult Index()
        {
            IList<Park> allParks = parkDAL.GetAllParks();

            return View("Index", allParks);
        }

        public ActionResult ParkDetail()
        {
            List<Park> parkDetails = parkDetail.ParkDetail();

            return View("ParkDetail", parkDetails);
        }

    }
}