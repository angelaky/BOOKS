using AutoMapper;
using BooksBlog.ViewModels;
using BooksBlog.Models;
using BooksBlog.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksBlog.Areas.Administration.ViewModels;
using BookBlog.Common.Caching;

namespace BooksBlog.Controllers
{
    public class HomeController : BaseController
    {
        private IPostService postsService;
        private ICategoryService categoryService;
        private ICacheService cache;
        public HomeController(IPostService service, ICategoryService categoryService, ICacheService cache)
        {
            this.cache = cache;
            this.postsService = service;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var dbPosts = this.cache.Get<ICollection<Post>>("allPosts", () =>
            {
                return postsService.GetAll().ToList();
            }, 10);

            var posts = Mapper.Map<List<Post>,
                List<GuestPostViewModel>>(postsService.GetAll().ToList());

            ViewData["Categories"] = Mapper.Map<List<Categories>,
                List<CategoryViewModel>>(categoryService.GetAll().ToList());

            ViewData["FeaturedPosts"] = posts.OrderBy(i => i.Comments.Count).Take(10);

            
            return View(posts);
        }

        public ActionResult Info(int id)
        {
            var post = Mapper.Map<GuestPostViewModel>(this.postsService.Find(id));
            if (post.Content.Length > 30)
            {
                post.SubHeader = post.Content.Substring(0, 30);
            }
            else
            {
                post.SubHeader = post.Content;
            }

            return View(post);
        }

        public ActionResult FilterByCategory(int id)
        {
            var posts = Mapper.Map<List<Post>,List<GuestPostViewModel>>(this.postsService.GetPosts(id).ToList());            

            return View(posts);
        }

        public ActionResult FilterByMonth(int monthId)
        {
            var posts = Mapper.Map<List<Post>, List<GuestPostViewModel>>(this.postsService.GetPostsByMonth(monthId).ToList());

            return View(posts);
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