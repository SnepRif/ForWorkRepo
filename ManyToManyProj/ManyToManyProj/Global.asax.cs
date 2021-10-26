﻿using ManyToManyProj.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ManyToManyProj
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new CourseDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
