using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAgent.WebApplication.Controllers
{
    public class EnrollController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            ViewBag.Title = "Enroll Page";
            return View();
        }
    }
}