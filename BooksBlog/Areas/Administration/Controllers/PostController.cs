using BooksBlog.Areas.Administration.ViewModels;
using BooksBlog.Controllers;
using BooksBlog.Models;
using BooksBlog.Services;
using BooksBlog.Services.Contracts;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BooksBlog.Areas.Administration.Controllers
{
    public class PostController : BaseController
    {
        // GET: Administration/Post
        private IPostService postsService;
        private IUsersService usersService;
        private ICategoryService categoriesService;

        public PostController(IPostService postService, IUsersService usersService, ICategoryService categoriesService)
        {
            this.postsService = postService;
            this.usersService = usersService;
            this.categoriesService = categoriesService;
        }

        // GET: Administration/Posts
        public ActionResult Index(int? page)
        {
            var posts = Mapper.Map<List<Post>,
                List<PostViewModel>>(postsService.GetAll().ToList());

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        // GET: Administration/Posts/Create
        public ActionResult Create()
        {
            PostViewModel postVM = new PostViewModel();         
            postVM.Categories = new SelectList(this.categoriesService.GetAll(), "Id", "Name");
            return View(postVM);
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel post, int Id)
        {
            if (ModelState.IsValid)
            {
                var dbPost = Mapper.Map<Post>(post);
                dbPost.Author = usersService.Find(User.Identity.GetUserId());
                dbPost.Category = categoriesService.Find(Id);
                this.postsService.Add(dbPost);
                return RedirectToAction("Index");
            }

            //ViewBag.AuthorId = new SelectList(this.postsService.GetAll(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        [ValidateInput(false)]
        // GET: Administration/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = this.postsService.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            PostViewModel postVM = Mapper.
                Map<PostViewModel>(post);

            postVM.Categories = new SelectList(this.categoriesService.GetAll(),"Id","Name", postVM.CategoryId);            
            return View(postVM);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
  
        [ValidateInput(false)]
        public ActionResult Edit(PostViewModel post, int Id)
        {
            if (ModelState.IsValid)
            {
                var dbPost = Mapper.Map<Post>(post);
                //dbPost.Category = categoriesService.Find(post.CategoryId);
                this.postsService.Update(dbPost);
                return RedirectToAction("Index");
            }

            //post.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
            post.Categories = new SelectList(this.categoriesService.GetAll());
            return View(post);
        }

        // GET: Administration/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = this.postsService.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Administration/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.postsService.Delete(id);
            return RedirectToAction("Index");
        }

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