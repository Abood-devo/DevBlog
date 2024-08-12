using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;


namespace devBlog.Pages.BlogPosts
{
    [Authorize]
    public class EditModel(IBlogPostService blogPostService, ITagService tagService, UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly IBlogPostService _blogPostService = blogPostService;
        private readonly ITagService _tagService = tagService;
		private readonly UserManager<IdentityUser> _userManager = userManager;

		[BindProperty]
        public BlogPost BlogPost { get; set; } = default!;

        [BindProperty]
        public List<Guid> SelectedTagIds { get; set; } = [];

        public List<Tag> Tags { get; set; } = [];

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

            var blogpost = await _blogPostService.GetBlogPostByIdAsync(id.Value);
            if (blogpost == null)
            {
                return NotFound();
            }

            if (blogpost.AuthorID != userid)
            {
                return Redirect("/blogposts/Details");
            }
            BlogPost = blogpost;

            // Populate AvailableTags and SelectedTagIds
            Tags = (await _tagService.GetAllTagsAsync()).ToList();
            var blogPostTags = (await _blogPostService.GetBlogPostTagsAsync(id.Value)).Select(t => t.TagID).ToList();
            SelectedTagIds = blogPostTags;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Tags = (await _tagService.GetAllTagsAsync()).ToList();
                return Page();
            }
            var user = _userManager.GetUserId(User);

            if (user == null)
            {
                return Challenge();
            }

            BlogPost.AuthorID = Guid.Parse(user);
            BlogPost.LastModifiedDate = DateTime.Now;

            // Handle the tags
            var existingTags = await _blogPostService.GetBlogPostTagsAsync(BlogPost.BlogPostID);

            var newTags = SelectedTagIds.Select(tagId => new BlogPostTag
            {
                BlogPostID = BlogPost.BlogPostID,
                TagID = tagId
            }).ToList();

            // Determine tags to remove and add
            var tagsToRemove = existingTags
                .Where(et => !SelectedTagIds.Contains(et.TagID))
                .Select(et => new BlogPostTag
                {
                    BlogPostID = BlogPost.BlogPostID,
                    TagID = et.TagID
                }).ToList();

            var tagsToAdd = newTags
                .Where(nt => !existingTags.Any(et => et.TagID == nt.TagID))
                .ToList();

            await _blogPostService.RemoveBlogPostTagsAsync(tagsToRemove);
            await _blogPostService.AddBlogPostTagsAsync(tagsToAdd);


            try
            {
                await _blogPostService.UpdateBlogPostAsync(BlogPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _blogPostService.BlogPostExists(BlogPost.BlogPostID))
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
    }
}
