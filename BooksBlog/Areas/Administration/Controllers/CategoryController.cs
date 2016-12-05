using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BooksBlog.Data;
using BooksBlog.Models;
using BooksBlog.Services.Contracts;
using BooksBlog.Areas.Administration.ViewModels;
using Microsoft.AspNet.Identity;
using BooksBlog.Controllers;

namespace BooksBlog.Areas.Administration.Controllers
{
    public class CategoryController : BaseController
    {
        private ICategoryService categoryService;
        private IUsersService usersService;

        public CategoryController(ICategoryService categoryService, IUsersService usersService)
        {
            this.categoryService = categoryService;
            this.usersService = usersService;
        }

        // GET: Administration/Category
        public ActionResult Index()
        {
            var categories = Mapper.Map<List<Categories>,
                List<CategoryViewModel>>(categoryService.GetAll().ToList());

            return View(categories);
        }

        // GET: Administration/Category/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Categories categories = db.Categories.Find(id);
        //    if (categories == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(categories);
        //}

        // GET: Administration/Category/Create
        public ActionResult Create()
        {
            CategoryViewModel categoryVM = new CategoryViewModel();
            return View(categoryVM);
        }

        // POST: Administration/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory= Mapper.Map<Categories>(category);
                dbCategory.Author = usersService.Find(User.Identity.GetUserId());
                this.categoryService.Add(dbCategory);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Administration/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categories category = this.categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoryViewModel categoryVM = Mapper.
                Map<CategoryViewModel>(category);
            //postVM.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.Id);
            return View(categoryVM);

        }

        // POST: Administration/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = Mapper.Map<Categories>(category);
                this.categoryService.Update(dbCategory);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Administration/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories category = this.categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.categoryService.Delete(id);
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
