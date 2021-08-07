using Microsoft.AspNet.Identity;
using Project_IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IA.Controllers
{
    public class ViewerController : Controller
    {
        // GET: Viewer
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.PostCategories.ToList());
        }


        public ActionResult Details (int postId)
        {
            var post = db.Posts.Find(postId);
            if(post==null)
            {
                return HttpNotFound();
            }
            Session["postId"] = postId;
            return View(post);
        }

        [Authorize]
        public ActionResult Comment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Comment(string comment)
        {
            var UserId = User.Identity.GetUserId();
            var postId = (int)Session["postId"];

            var post = new Comment();
            post.UserId = UserId;
            post.PostId = postId;
            post.comment = comment;
            post.ApplyDate = DateTime.Now;
            db.Comments.Add(post);
            db.SaveChanges();
            ViewBag.Result = "Your Comment was send";
            return View();
        }


        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Posts.Where(a => a.ArticleTitle.Contains(searchName)
            || a.EditorName.Contains(searchName)
            || a.PostCategory.ArticleType.Contains(searchName));
            return View(result);
        }

        public ActionResult LikePost(int postId)
        {

            Post post = db.Posts.FirstOrDefault(o => o.id == postId);
            if (post != null) {
                post.LikesCounter++;
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Viewer", new { postId = postId });

        }

        public ActionResult DisLikePost(int postId)
        {
            Post post = db.Posts.FirstOrDefault(o => o.id == postId);
            if (post != null)
            {
                post.DisLikesCounter++;
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Viewer", new { postId = postId });
        }
        public ActionResult GetComent()
        {
            var UserId = User.Identity.GetUserId();
            var Posts = from app in db.Comments
                        join post in db.Posts
                        on app.PostId equals post.id
                      // where post.User.Id == UserId
                        select app;
            return View(Posts.ToList());
        }


    }
}