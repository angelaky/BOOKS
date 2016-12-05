using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Models
{
    public class Post : BaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; } 
        
        public virtual Categories Category { get; set; }

        public virtual ICollection<Comments> Comments
        {
            get;
            set;
        }

        public virtual ICollection<Tags> Tags { get; set; }

    }
}
