using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;

namespace devBlog.Pages.Admin
{
	[Authorize(Roles = "Admin")]
    public class ManageBlogsModel : PageModel
    {
		private readonly IBlogPostService _blogPostService;

        public ManageBlogsModel(IBlogPostService blogPostService)
		{
			_blogPostService = blogPostService;
		}

        public IList<BlogPost>? PendingBlogs { get; set; }
        public IList<BlogPost>? ApprovedBlogs { get; set; }
		public void OnGet()
		{
			PendingBlogs = _blogPostService.GetPendingBlogPostsAsync().Result.ToList();

			ApprovedBlogs = _blogPostService.GetApprovedBlogPostsAsync().Result.ToList();
		}

		public async Task<IActionResult> OnPostApproveAsync(Guid id)
        {
            var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.IsApproved = true;
            await _blogPostService.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSuspendAsync(Guid id)
        {
			var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
			if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.IsApproved = false;
			await _blogPostService.SaveChangesAsync();

			return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
			var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
			if (blogPost == null)
            {
                return NotFound();
            }

			await _blogPostService.DeleteBlogPostAsync(id);
			await _blogPostService.SaveChangesAsync();

			return RedirectToPage();
        }

        public async Task<IActionResult> OnPostReapproveAsync(Guid id)
        {
			var blogPost = await _blogPostService.GetBlogPostByIdAsync(id);
			if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.IsApproved = true;
			await _blogPostService.SaveChangesAsync();

			return RedirectToPage();
        }
    }
}
