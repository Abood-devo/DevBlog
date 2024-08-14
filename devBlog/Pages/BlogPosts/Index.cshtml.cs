using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;

namespace devBlog.Pages.BlogPosts
{
    public class IndexModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        public IndexModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public IList<BlogPostDTO> BlogPost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BlogPost = (await _blogPostService.GetBlogPostsAsync()).ToList();
        }
    }
}
