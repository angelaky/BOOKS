using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BooksBlog.Data;
using BooksBlog.Models;
using BooksBlog.Services.Contracts;
using BooksBlog.ViewModels;
using Microsoft.AspNet.Identity;
using BooksBlog.Services;
using BooksBlog.Areas.Administration.ViewModels;

namespace BooksBlog.Controllers
{
    public class CommentsController : BaseController
    {
        private ICommentService commentService;
        private IPostService postsService;
        private IUsersService usersService;

        public CommentsController(ICommentService commentService, IPostService postService, IUsersService usersService)
        {
            //this.cache = cache;
            this.commentService = commentService;
            this.postsService = postService;
            this.usersService = usersService;
        }

        [HttpGet]
        public ActionResult _AddComment(int Id)
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult AddCommentAjax(CommentViewModel commentViewModel, int postId)
        {

            if (ModelState.IsValid)
            {
                var dbComment = Mapper.Map<Comments>(commentViewModel);
                dbComment.Author = usersService.Find(User.Identity.GetUserId());
                dbComment.Post = postsService.Find(postId);
                this.commentService.Add(dbComment);
            }

            //var posts = Mapper.Map<List<Post>,
            //    List<GuestPostViewModel>>(postsService.GetAll().ToList());
                                   
            var post = Mapper.Map<GuestPostViewModel>(postsService.Find(postId));
            return PartialView("_commentsList", post);
        }

        // GET: Comments
        //public ActionResult Index()
        //{
        //    return View(db.Comments.ToList());
        //}

        //// GET: Comments/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comments comments = db.Comments.Find(id);
        //    if (comments == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comments);
        //}

        //// GET: Comments/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Comments/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Content,CreatedOn,IsDeleted")] Comments comments)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Comments.Add(comments);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(comments);
        //}

        //// GET: Comments/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comments comments = db.Comments.Find(id);
        //    if (comments == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comments);
        //}

        //// POST: Comments/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Content,CreatedOn,IsDeleted")] Comments comments)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(comments).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(comments);
        //}

        //// GET: Comments/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comments comments = db.Comments.Find(id);
        //    if (comments == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comments);
        //}

        //// POST: Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Comments comments = db.Comments.Find(id);
        //    db.Comments.Remove(comments);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
