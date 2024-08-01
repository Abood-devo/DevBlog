using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using devBlog.Data;
using devBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace devBlog.Pages.BlogPosts
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly devBlogContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(devBlogContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult OnGet()
        {
            Tags = _context.Tag.ToList();
            return Page();
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; } = default!;
        [BindProperty]
        public List<Guid> SelectedTags { get; set; } = new List<Guid>();

        public List<Tag> Tags { get; set; } = new List<Tag>();


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Tags = _context.Tag.ToList();
                return Page();
            }

            var user = _userManager.GetUserId(User);

            if (user == null)
            {
                return Challenge();
            }
            BlogPost.AuthorID = Guid.Parse(user);

            foreach (var tagId in SelectedTags)
            {
                BlogPost.BlogPostTags.Add(new BlogPostTag { BlogPostID = BlogPost.BlogPostID, TagID = tagId });
            }

            _context.BlogPost.Add(BlogPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
