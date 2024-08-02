using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using devBlog.Data;
using devBlog.Models;

namespace devBlog.Pages.BlogPosts
{
    public class IndexModel : PageModel
    {
        private readonly devBlog.Data.devBlogContext _context;

        public IndexModel(devBlog.Data.devBlogContext context)
        {
            _context = context;
        }

        public IList<BlogPost> BlogPost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BlogPost = await _context.BlogPost
                .Where(b => b.IsApproved && b.IsPublished)
                .ToListAsync();
        }
    }
}
