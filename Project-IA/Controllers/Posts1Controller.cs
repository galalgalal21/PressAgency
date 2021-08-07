using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Project_IA.Models;

namespace Project_IA.Controllers
{
   [Authorize(Roles = "Editor")] //[Authorize(Roles ="Editor")]
    public class Posts1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public string GetUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

           return userIdClaim.Value;

        }
        // GET: Posts1
        public ActionResult Index()
        {
            List<Post> posts = new List<Post>();
            try {
                string Id = GetUserId();

                posts = db.Posts.Where(o => o.UserId == Id).Include(p => p.PostCategory).ToList();
                return View(posts.ToList());

            }
            catch (Exception ex)
            {
                return View(posts.ToList());

            }
        }

        


        // GET: Posts1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts1/Create
        public ActionResult Create()
        {
            ViewBag.PostCategoryId = new SelectList(db.PostCategories, "id", "ArticleTitle");
            return View();
        }

        // POST: Posts1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                post.ArticleImage = upload.FileName;
                post.UserId = User.Identity.GetUserId();
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostCategoryId = new SelectList(db.PostCategories, "id", "ArticleTitle", post.PostCategoryId);
            return View(post);
        }

        // GET: Posts1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostCategoryId = new SelectList(db.PostCategories, "id", "ArticleTitle", post.PostCategoryId);
            return View(post);
        }

        // POST: Posts1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), post.ArticleImage);
                if (upload!=null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    post.ArticleImage = upload.FileName;
                }
                
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostCategoryId = new SelectList(db.PostCategories, "id", "ArticleTitle", post.PostCategoryId);
            return View(post);
        }

        // GET: Posts1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
