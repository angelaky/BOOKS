using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBlog.Models
{
    public class BaseModel
    {
            public int Id { get; set; }

            public DateTime? CreatedOn { get; set; }

            public bool IsDeleted { get; set; }
        }
}

