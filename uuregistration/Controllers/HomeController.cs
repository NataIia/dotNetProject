using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uuregistration.DataAccessLayer;

namespace uuregistration.Controllers
{
    
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

//        [Authorize(Roles = "testrol3")]
        public ActionResult About()
        {
            ViewBag.Message = "For testing purposes several hardcoded users with different roles where created";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}