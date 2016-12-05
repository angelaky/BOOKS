using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BooksBlog.Mapping;

namespace BooksBlog.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        protected IMapper Mapper
        {
            get

            {
                return AutoMapperConfiguration.Config.CreateMapper();
            }
        }

    }
}