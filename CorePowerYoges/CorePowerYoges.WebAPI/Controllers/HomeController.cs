using CorePowerYoges.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorePowerYoges.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //using (var context = new CorePowerYogesContext())
            //{
            //    var states = context.States.ToList();
            //    foreach (var state in states)
            //    {
            //        var s = state.Name;
            //    }
            //}

            return View();
        }
    }
}
