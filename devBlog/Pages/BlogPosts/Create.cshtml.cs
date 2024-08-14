using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;

namespace devBlog.Pages.BlogPosts
{
    [Authorize]
    public class CreateModel(IBlogPostService blogPostService, ITagService tagService, UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly IBlogPostService _blogPostService = blogPostService;
		private readonly ITagService _tagService = tagService;
		private readonly UserManager<IdentityUser> _userManager = userManager;

        public IActionResult OnGet()
        {
            Tags = _tagService.GetAllTagsAsync().Result.ToList();
            return Page();
        }

        [BindProperty]
        public BlogPostDTO BlogPost { get; set; } = default!;
        [BindProperty]
        public List<Guid> SelectedTags { get; set; } = [];

        public List<TagDTO> Tags { get; set; } = [];

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Tags = _tagService.GetAllTagsAsync().Result.ToList();
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
                BlogPost.BlogPostTags.Add(new BlogPostTagDTO { BlogPostID = BlogPost.BlogPostID, TagID = tagId });
            }

            await _blogPostService.CreateBlogPostAsync(BlogPost);

            // Redirect to a success page or the same page with a success message
            TempData["SuccessMessage"] = "Your blog has been submitted and is pending approval from admins.";
            return RedirectToPage("./Index");
        }
    }
}
