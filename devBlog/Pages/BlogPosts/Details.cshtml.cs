using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using devBlog.Data;
using devBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace devBlog.Pages.BlogPosts
{
	[Authorize]
	public class DetailsModel : PageModel
    {
        private readonly devBlog.Data.devBlogContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(devBlog.Data.devBlogContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public BlogPost BlogPost { get; set; } = default!;
        public Guid CurrentUserId { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _context.BlogPost.FirstOrDefaultAsync(m => m.BlogPostID == id);
            if (blogpost == null)
            {
                return NotFound();
            }
            else
            {
                BlogPost = blogpost;
				var userId = _userManager.GetUserId(User);
                CurrentUserId = Guid.Parse(userId);
            }
            return Page();
        }
    }
}
