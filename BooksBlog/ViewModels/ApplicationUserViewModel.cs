using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksBlog.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CommentsCount { get; set; }
        public string LastActivity { get; set; }

    }
}