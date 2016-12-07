using BooksBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksBlog.Areas.Administration.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public ApplicationUserViewModel Author { get; set; }

        //public ICollection<Post>

        public DateTime? CreatedOn { get; set; }
    }
}