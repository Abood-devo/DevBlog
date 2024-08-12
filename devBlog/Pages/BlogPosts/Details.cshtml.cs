using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;

namespace devBlog.Pages.BlogPosts
{
	[Authorize]
	public class DetailsModel(IBlogPostService blogPostService, UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly IBlogPostService _blogPostService = blogPostService;
        private readonly UserManager<IdentityUser> _userManager = userManager;

		public BlogPost BlogPost { get; set; } = default!;
		public IEnumerable<Tag> Tags { get; set; } = default!;
		public Guid CurrentUserId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var blogpost = await _blogPostService.GetBlogPostByIdAsync(id.Value);
            var blogposttags = await _blogPostService.GetBlogPostTagsAsync(id.Value);

            if (blogpost == null)
            {
                return NotFound();
            }
            else
            {
                BlogPost = blogpost;
                Tags = blogposttags;

                var userId = _userManager.GetUserId(User);
				if (userId != null)
				{
					CurrentUserId = Guid.Parse(userId);
				}
            }
            return Page();
        }
    }
}
