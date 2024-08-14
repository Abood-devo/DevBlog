using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;

namespace devBlog.Pages.BlogPosts
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(IBlogPostService blogPostService, UserManager<IdentityUser> userManager)
        {
            _blogPostService = blogPostService;
            _userManager = userManager;
        }

        [BindProperty]
        public BlogPostDTO BlogPost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _blogPostService.GetBlogPostByIdAsync(id.Value);
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
            else
            {
                BlogPost = blogpost;
                if (blogpost.AuthorID != userid)
                {
                    return Redirect("/blogposts/Details");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var blogpost = await _context.BlogPost.FindAsync(id);
            var blogpost = await _blogPostService.GetBlogPostByIdAsync(id.Value);
            if (blogpost != null)
                await _blogPostService.DeleteBlogPostAsync(blogpost.BlogPostID);
            
            // Redirect index page with a success delete operation message
            TempData["SuccessMessage"] = "Your blog has been deleted.";
            return RedirectToPage("./Index");
        }
    }
}
