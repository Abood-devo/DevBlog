using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using devBlog.Data;
using devBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace devBlog.Pages.BlogPosts
{
	[Authorize]
    public class EditModel : PageModel
    {
        private readonly devBlog.Data.devBlogContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(devBlog.Data.devBlogContext context, UserManager<IdentityUser> userManager)
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

            var blogpost =  await _context.BlogPost.FirstOrDefaultAsync(m => m.BlogPostID == id);
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

            if (blogpost.AuthorID != userid)
            {
                return Redirect("/blogposts/Create");
            }
            BlogPost = blogpost;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = _userManager.GetUserId(User);

            if (user == null)
            {
                return Challenge();
            }

            BlogPost.AuthorID = Guid.Parse(user);


            _context.Attach(BlogPost).State = EntityState.Modified;

            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(BlogPost.BlogPostID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BlogPostExists(Guid id)
        {
            return _context.BlogPost.Any(e => e.BlogPostID == id);
        }
    }
}
