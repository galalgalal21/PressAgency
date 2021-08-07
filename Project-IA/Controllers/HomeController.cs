using Project_IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IA.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            if (User.IsInRole(("Editor")))
            {

                return RedirectToAction("Index", "Posts1");

            }
            else if (User.IsInRole(("Admin"))) {
                return RedirectToAction("Index", "Posts");

            }
            else
            {
                return RedirectToAction("Index", "Viewer");


            }

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