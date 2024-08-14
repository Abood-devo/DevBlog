using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
        Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId);
        Task<BlogPost> GetBlogPostByIdAsync(Guid blogPostId);
        Task<IEnumerable<BlogPost>> GetBlogPostsAsync();
        Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost);
        Task RemoveBlogPostTags(IEnumerable<BlogPostTag> blogPostTags);
        Task AddBlogPostTags(IEnumerable<BlogPostTag> blogPostTags);
        Task<IEnumerable<Tag>> GetBlogPostTagsAsync(Guid blogPostId);
    }
}
