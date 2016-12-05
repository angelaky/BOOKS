using BooksBlog.Data.Repositories;
using BooksBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Data
{
    public class BooksBlogData : IBooksBlogData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public BooksBlogData()
            : this(new BooksBlogDbContext())
        {
        }

        public BooksBlogData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                return this.GetRepository<Post>();
            }
        }

        public IRepository<Categories> Categories
        {
            get
            {
                return this.GetRepository<Categories>();
            }
        }

        public IRepository<Comments> Comments
        {
            get
            {
                return this.GetRepository<Comments>();
            }
        }

        public IRepository<Tags> Tags
        {
            get
            {
                return this.GetRepository<Tags>();
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

    }
}
