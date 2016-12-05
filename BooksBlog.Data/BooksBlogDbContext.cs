using BooksBlog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Data
{
    public class BooksBlogDbContext : IdentityDbContext
    {
        public BooksBlogDbContext()
            : base("BooksBlogDB")
        {
            
        }

        public IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        public IDbSet<Post> Posts
        {
            get;
            set;
        }

        public IDbSet<Categories> Categories
        {
            get;
            set;
        }

        public IDbSet<Comments> Comments
        {
            get;
            set;
        }

        public IDbSet<Tags> Tags
        {
            get;
            set;
        }

        public static BooksBlogDbContext Create()
        {
            return new BooksBlogDbContext();
        }

        public System.Data.Entity.DbSet<BooksBlog.Areas.Administration.ViewModels.PostViewModel> PostViewModels { get; set; }
    }
}
