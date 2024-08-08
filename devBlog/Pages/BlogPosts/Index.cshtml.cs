using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Entities;
using BusinessLogic.Interfaces;

namespace devBlog.Pages.BlogPosts
{
    public class IndexModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        public IndexModel(IBlogPostService blogPostRepository)
        {
            _blogPostService = blogPostRepository;
        }

        public IList<BlogPost> BlogPost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BlogPost = (await _blogPostService.GetBlogPostsAsync()).ToList();
        }
    }
}
