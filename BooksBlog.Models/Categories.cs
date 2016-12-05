using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Models
{
    public class Categories : BaseModel
    {
        public string Name { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Post> Posts
        {
            get;
            set;
        }

    }
}
