using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using devBlog.Data;
using devBlog.Models;

namespace devBlog.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly devBlog.Data.devBlogContext _context;

        public IndexModel(devBlog.Data.devBlogContext context)
        {
            _context = context;
        }

        public IList<Tag> Tag { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tag = await _context.Tag.ToListAsync();
        }
    }
}
