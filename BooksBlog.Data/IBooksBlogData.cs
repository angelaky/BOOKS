using BooksBlog.Data.Repositories;
using BooksBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Data
{
    public interface IBooksBlogData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Post> Posts
        {
            get;
        }

        IRepository<Categories> Categories
        {
            get;
        }

        IRepository<Comments> Comments
        {
            get;
        }

        IRepository<Tags> Tags
        {
            get;
        }

        IRepository<T> GetRepository<T>() where T : class;
    }
}
