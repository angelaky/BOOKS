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
    public class CategoryService: BaseService<Categories>, ICategoryService
    {
        public CategoryService(IBooksBlogData data)
            : base(data)
        {
    }

    public override IQueryable<Categories> GetAll()
    {
        return base.GetAll().OrderByDescending(p => p.CreatedOn);
    }

    public override void Add(Categories entity)
    {
        entity.CreatedOn = DateTime.Now;
        base.Add(entity);
        base.SaveChanges();
    }
}
}
