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
    public class CommentService : BaseService<Comments>, ICommentService
    {
        public CommentService(IBooksBlogData data)
            : base(data)
        {
        }

        public override IQueryable<Comments> GetAll()
        {
            return base.GetAll().OrderByDescending(p => p.CreatedOn);
        }

        public override void Add(Comments entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        public IEnumerable<Comments> GetCommentsByUser(string authorId)
        {
            return base.GetAll().Where(p => p.Author.Id == authorId);
        }

        public IEnumerable<Comments> LastActivity(string authorId)
        {
            return base.GetAll().Where(p => p.Author.Id == authorId).OrderByDescending(p => p.CreatedOn);
        }
    }
}
