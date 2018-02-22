using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAgent.WebApplication.Controllers
{
    public class AgentController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Agents Page";

            return View();
        }
    }
}