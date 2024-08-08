using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
        Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId);
        Task<BlogPost> GetBlogPostByIdAsync(Guid blogPostId);
        Task<IEnumerable<BlogPost>> GetBlogPostsAsync();
        Task<IEnumerable<BlogPost>> GetPendingBlogPostsAsync();
        Task<IEnumerable<BlogPost>> GetApprovedBlogPostsAsync();
        Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost);
        void RemoveBlogPostTags(IEnumerable<BlogPostTag> blogPostTags);
        void AddBlogPostTags(IEnumerable<BlogPostTag> blogPostTags);
        Task<IEnumerable<Tag>> GetBlogPostTagsAsync(Guid blogPostId);
        Task SaveChangesAsync();
    }
}
