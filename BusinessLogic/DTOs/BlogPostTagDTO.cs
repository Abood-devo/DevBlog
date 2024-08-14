using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class BlogPostTagDTO
    {
        public Guid BlogPostID { get; set; }
        public BlogPost BlogPost { get; set; } = default!;

        public Guid TagID { get; set; }
        public Tag Tag { get; set; } = default!;
    }
}
