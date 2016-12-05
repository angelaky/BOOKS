using BooksBlog.Areas.Administration.ViewModels;
using BooksBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksBlog.ViewModels
{
    public class GuestPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SubHeader { get; set; }

        public ApplicationUserViewModel Author { get; set; }

        public CategoryViewModel Category { get; set; }

        public DateTime? CreatedOn { get; set; }

        public ICollection<Comments> Comments { get; set; }

    }
}