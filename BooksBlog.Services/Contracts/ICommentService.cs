using BooksBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Services.Contracts
{
    public interface ICommentService : IService<Comments>
    {
            IQueryable<Comments> GetAll();
    }
}
