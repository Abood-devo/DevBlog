using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IManagePostsService
    {
        Task<IEnumerable<BlogPostDTO>> GetApprovedBlogPostsAsync();
        Task<IEnumerable<BlogPostDTO>> GetPendingBlogPostsAsync();
        Task<BlogPost> ApproveBlogPostAsync(Guid blogPostId);
        Task<BlogPost> RejectBlogPostAsync(Guid blogPostId);
        Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId);
        Task<BlogPost> SuspendBlogPostAsync(Guid blogPostId);
    }
}
