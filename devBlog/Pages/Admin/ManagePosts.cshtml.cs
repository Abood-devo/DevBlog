using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;

namespace devBlog.Pages.Admin
{
	[Authorize(Roles = "Admin")]
    public class ManageBlogsModel(IManagePostsService managePostsService) : PageModel
    {
		private readonly IManagePostsService _managePostsService = managePostsService;

        public IList<BlogPostDTO>? PendingBlogs { get; set; }
        public IList<BlogPostDTO>? ApprovedBlogs { get; set; }
		public void OnGet()
		{
			PendingBlogs = _managePostsService.GetPendingBlogPostsAsync().Result.ToList();
			ApprovedBlogs = _managePostsService.GetApprovedBlogPostsAsync().Result.ToList();
		}

		public async Task<IActionResult> OnPostApproveAsync(Guid id)
        {
            await _managePostsService.ApproveBlogPostAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSuspendAsync(Guid id)
        {
			await _managePostsService.SuspendBlogPostAsync(id);
			return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
			await _managePostsService.DeleteBlogPostAsync(id);
			return RedirectToPage();
        }

        public async Task<IActionResult> OnPostReapproveAsync(Guid id)
        {
			await _managePostsService.ApproveBlogPostAsync(id);
			return RedirectToPage();
        }
        public async Task<IActionResult> OnPostRejectAsync(Guid id)
        {
            await _managePostsService.RejectBlogPostAsync(id);
            return RedirectToPage();
        }
    }
}
