using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoºMVC.Models;
using System.Web.Mvc;

namespace ProyectoºMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}