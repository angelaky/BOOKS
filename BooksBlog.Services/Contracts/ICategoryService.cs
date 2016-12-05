using BooksBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Services.Contracts
{
    public interface ICategoryService : IService<Categories>
    {
        IQueryable<Categories> GetAll();
    }
}
