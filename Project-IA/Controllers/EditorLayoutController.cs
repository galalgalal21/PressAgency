using Microsoft.AspNet.Identity;
using Project_IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IA.Controllers
{
    public class EditorLayoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: EditorLayout
        public ActionResult Index()
        {
            return View();
        }


        
    }
}