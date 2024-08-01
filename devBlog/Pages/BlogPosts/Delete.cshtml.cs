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
    public class DeleteModel : PageModel
    {
        private readonly devBlog.Data.devBlogContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(devBlog.Data.devBlogContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _context.BlogPost.FirstOrDefaultAsync(m => m.BlogPostID == id);
            var user = _userManager.GetUserId(User);
            if (user == null)
            {
                return Challenge();
            }
            var userid = Guid.Parse(user);

            if (blogpost == null)
            {
                return NotFound();
            }
            else
            {
                BlogPost = blogpost;
                if (blogpost.AuthorID != userid)
                {
                    return Redirect("/blogposts/Create");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _context.BlogPost.FindAsync(id);
            if (blogpost != null)
            {
                BlogPost = blogpost;
                _context.BlogPost.Remove(BlogPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
