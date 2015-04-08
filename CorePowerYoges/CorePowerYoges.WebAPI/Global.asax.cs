using CorePowerYoges.DAL;
using CorePowerYoges.DAL.Migrations;
using CorePowerYoges.WebAPI.App_Start;
using CorePowerYoges.WebAPI.DependencyResolution;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CorePowerYoges.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CorePowerYogesContext, Configuration>());

            //Database.SetInitializer(
            //    new DropCreateDatabaseAlways<CorePowerYogesContext>());
        }
    }
}
