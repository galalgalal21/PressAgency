using Project_IA.Models;
using Project_IA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IA.Controllers
{
    public class UserAccountsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: UserAccounts
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            List<UserViewModel> usersLst = new List<UserViewModel>();
            foreach(var user in users)
            {
                usersLst.Add(new UserViewModel { 
                Id=user.Id,
                username=user.UserName,
                Email=user.Email,
                userType=user.UserType

                });
            }
            return View(usersLst);
        }
        public ActionResult Delete(string userId)
        {
            db.Users.Remove(db.Users.Find(userId));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}