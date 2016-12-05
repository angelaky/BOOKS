using BooksBlog.Models;
using BooksBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksBlog.Areas.Administration.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title content")]
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUserViewModel Author { get; set; }

        public CategoryViewModel Category { get; set; }
        public SelectList Categories { get; set; }
        public DateTime? CreatedOn { get; set; }

        public ICollection<Comments> Comments { get; set; }

    }
}