using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public interface IParkSqlDAL
    {
        IList<Park> GetAllParks();

    }
}