using BooksBlog.Data;
using BooksBlog.Models;
using BooksBlog.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IBooksBlogData data)
            : base(data)
        {
        }

        public override IQueryable<Post> GetAll()
        {
            return base.GetAll().OrderByDescending(p => p.CreatedOn);
        }

        public override void Add(Post entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        public IEnumerable<Post> GetPosts(int catId)
        {
            return base.GetAll().Where(p => p.Category.Id == catId).ToList();
        }
    }
}
