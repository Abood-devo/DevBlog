using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using devBlog.Data;
using devBlog.Models;
using Microsoft.AspNetCore.Authorization;

namespace devBlog.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class ManageBlogsModel : PageModel
    {
        private readonly devBlogContext _context;

        public ManageBlogsModel(devBlogContext context)
        {
            _context = context;
        }

        public IList<BlogPost> BlogPosts { get; set; }
        public IList<BlogPost> PendingBlogs { get; set; }
        public IList<BlogPost> ApprovedBlogs { get; set; }
        public async Task OnGetAsync()
        {
            PendingBlogs = await _context.BlogPost
            .Where(b => !b.IsApproved && b.IsPublished)
            .ToListAsync();

            ApprovedBlogs = await _context.BlogPost
                .Where(b => b.IsApproved)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostApproveAsync(Guid id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.IsApproved = true;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRejectAsync(Guid id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.BlogPost.Remove(blogPost);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSuspendAsync(Guid id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.IsPublished = false;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.BlogPost.Remove(blogPost);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostReapproveAsync(Guid id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.IsPublished = true;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
