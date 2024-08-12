using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;

namespace devBlog.Pages.BlogPosts
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;
		private readonly ITagService _tagService;
		private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(IBlogPostService blogPostService, ITagService tagService, UserManager<IdentityUser> userManager)
        {
            _blogPostService = blogPostService;
			_tagService = tagService;
            _userManager = userManager;
        }


        public IActionResult OnGet()
        {
            Tags = _tagService.GetAllTagsAsync().Result.ToList();
            return Page();
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; } = default!;
        [BindProperty]
        public List<Guid> SelectedTags { get; set; } = [];

        public List<Tag> Tags { get; set; } = [];


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
            BlogPost.CreationDate = DateTime.Now;
            BlogPost.LastModifiedDate = DateTime.Now;
            BlogPost.IsApproved = false;

            foreach (var tagId in SelectedTags)
            {
                BlogPost.BlogPostTags.Add(new BlogPostTag { BlogPostID = BlogPost.BlogPostID, TagID = tagId });
            }

            await _blogPostService.CreateBlogPostAsync(BlogPost);

            // Redirect to a success page or the same page with a success message
            TempData["SuccessMessage"] = "Your blog has been submitted and is pending approval from admins.";
            return RedirectToPage("./Index");
        }
    }
}
