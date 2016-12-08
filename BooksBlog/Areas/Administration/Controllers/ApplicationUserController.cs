using BooksBlog.Controllers;
using BooksBlog.Models;
using BooksBlog.Services.Contracts;
using BooksBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksBlog.Areas.Administration.Controllers
{
    public class ApplicationUserController : BaseController
    {
        
        private IUsersService usersService;
        private ICommentService commentsService;

        public ApplicationUserController(IUsersService usersService, ICommentService commentsService)
        {
            
            this.usersService = usersService;
            this.commentsService = commentsService;
        }

        // GET: Administration/ApplicationUser
        [Authorize(Roles = "AppAdmin")]
        public ActionResult Index()
        {
            var usersVM = Mapper.Map<List<ApplicationUser>,
                List<ApplicationUserViewModel>>(usersService.GetAll().ToList());
            

            foreach (var user in usersVM)
            {
                user.CommentsCount = commentsService.GetCommentsByUser(user.Id).Count().ToString();
                if (user.CommentsCount == "0")
                {
                    user.LastActivity = "None";
                }
                else
                {
                    user.LastActivity = commentsService.LastActivity(user.Id).First().CreatedOn.ToString();
                }
            }
            return View(usersVM);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(string userId)
        {
            this.usersService.Delete(userId);
            return RedirectToAction("Index", "ApplicationUser");
        }

    }
}