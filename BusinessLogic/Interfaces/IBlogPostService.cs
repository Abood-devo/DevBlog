using DataAccess.Entities;

namespace BusinessLogic.Interfaces
{
	public interface IBlogPostService
    {
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
        Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId);
        Task<BlogPost> GetBlogPostByIdAsync(Guid blogPostId);
        Task<IEnumerable<BlogPost>> GetBlogPostsAsync();
        Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost);
        Task<IEnumerable<Tag>> GetBlogPostTagsAsync(Guid blogPostId);
        Task AddBlogPostTagsAsync(IEnumerable<BlogPostTag> blogPostTags);
        Task RemoveBlogPostTagsAsync(IEnumerable<BlogPostTag> blogPostTags);
        Task<bool> BlogPostExists(Guid id);
        Task<IEnumerable<BlogPost>> GetApprovedBlogPostsAsync();
        Task<IEnumerable<BlogPost>> GetPendingBlogPostsAsync();
		Task SaveChangesAsync();
	}
}
