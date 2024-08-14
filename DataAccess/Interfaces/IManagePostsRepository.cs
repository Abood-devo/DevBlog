using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IManagePostsRepository
    {
    Task<IEnumerable<BlogPost>> GetApprovedBlogPostsAsync();
    Task<IEnumerable<BlogPost>> GetPendingBlogPostsAsync();
    Task<BlogPost> ApproveBlogPostAsync(Guid blogPostId);
    Task<BlogPost> RejectBlogPostAsync(Guid blogPostId);
    Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId);
    Task<BlogPost> SuspendBlogPostAsync(Guid blogPostId);
    }
}
