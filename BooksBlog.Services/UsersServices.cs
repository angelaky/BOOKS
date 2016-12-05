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
    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IBooksBlogData data)
            : base(data)
        {
        }

    }
}
