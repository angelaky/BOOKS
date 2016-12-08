using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Models
{
    public class Post : BaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual string Author_Id { get; set; }

        [ForeignKey("Author_Id")]
        public virtual ApplicationUser Author { get; set; } 
        
        public virtual Categories Category { get; set; }

        public int CategoryId { get; set; }

        public virtual ICollection<Comments> Comments
        {
            get;
            set;
        }

        public virtual ICollection<Tags> Tags { get; set; }

    }
}
