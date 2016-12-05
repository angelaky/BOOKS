using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BooksBlog.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Add Comment")]
        public string Content
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public int PostId
        {
            get;
            set;
        }
    }
}