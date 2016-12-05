using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Models
{
    public class Comments : BaseModel
    {
        public string Content { get; set; }
        public virtual Post Post { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}
