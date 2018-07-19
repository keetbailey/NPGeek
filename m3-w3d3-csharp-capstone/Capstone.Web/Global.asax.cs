using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Capstone.Web.DAL;
////using Capstone.Web.DAL.Interfaces;
//using Ninject;
//using Ninject.Web.Common;

namespace Capstone.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //protected override IKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();

        //    string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=DvdStore;Integrated Security=True";

        //    kernel.Bind<IFilmDAL>().To<FilmDAL>().WithConstructorArgument("connectionString", connectionString);
        //    kernel.Bind<IActorDAL>().To<ActorDAL>().WithConstructorArgument("connectionString", connectionString);
        //    kernel.Bind<ICustomerDAL>().To<CustomerDAL>().WithConstructorArgument("connectionString", connectionString);

        //    return kernel;
        //}
    }
}
