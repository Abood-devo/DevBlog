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
        
        // Additional properties for tags
        public SelectList AvailableTags { get; set; } = default!;
        [BindProperty]
        public List<Guid> SelectedTagIds { get; set; } = new List<Guid>();
        
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var user = _userManager.GetUserId(User);
            if (user == null)
            {
                return Challenge();
            }
            var userid = Guid.Parse(user);

            var blogpost = await _context.BlogPost
                .Include(bp => bp.BlogPostTags) // Include BlogPostTags to access related tags
                .ThenInclude(bt => bt.Tag)
                .FirstOrDefaultAsync(m => m.BlogPostID == id);
            if (blogpost == null)
            {
                return NotFound();
            }

            if (blogpost.AuthorID != userid)
            {
                return Redirect("/blogposts/Create");
            }
            BlogPost = blogpost;

            // Populate AvailableTags and SelectedTagIds
            AvailableTags = new SelectList(await _context.Tag.ToListAsync(), "TagID", "Name");
            SelectedTagIds = blogpost.BlogPostTags.Select(bt => bt.TagID).ToList();
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

            // Handle the tags
            var existingTags = _context.BlogPostTag
                .Where(bpt => bpt.BlogPostID == BlogPost.BlogPostID)
                .ToList();

            var newTags = SelectedTagIds.Select(tagId => new BlogPostTag
            {
                BlogPostID = BlogPost.BlogPostID,
                TagID = tagId
            }).ToList();

            // Determine tags to remove and add
            var tagsToRemove = existingTags.Where(et => !SelectedTagIds.Contains(et.TagID)).ToList();
            var tagsToAdd = newTags.Where(nt => !existingTags.Any(et => et.TagID == nt.TagID)).ToList();

            // Remove tags not selected
            _context.BlogPostTag.RemoveRange(tagsToRemove);

            // Add new tags
            _context.BlogPostTag.AddRange(tagsToAdd);
            
            // udate the last modified date
			BlogPost.LastModifiedDate = DateTime.Now;
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
