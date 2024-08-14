using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using BusinessLogic.Extensions;

namespace BusinessLogic.Services
{
    public class ManagePostsService(IManagePostsRepository managePostsRepository) : IManagePostsService
    {
        private readonly IManagePostsRepository _managePostsRepository = managePostsRepository;

        public async Task<IEnumerable<BlogPostDTO>> GetApprovedBlogPostsAsync()
        {
            var approvedBlogPosts = await _managePostsRepository.GetApprovedBlogPostsAsync();
            return approvedBlogPosts.Select(bp => bp.ToDTO()).ToList();
        }

        public async Task<IEnumerable<BlogPostDTO>> GetPendingBlogPostsAsync()
        {
            var pendingBlogPosts = await _managePostsRepository.GetPendingBlogPostsAsync();
            return pendingBlogPosts.Select(bp => bp.ToDTO()).ToList();
        }
        public async Task<BlogPost> ApproveBlogPostAsync(Guid blogPostId)
        {
            return await _managePostsRepository.ApproveBlogPostAsync(blogPostId);
        }

        public async Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId)
        {
            return await _managePostsRepository.DeleteBlogPostAsync(blogPostId);
        }
        public async Task<BlogPost> RejectBlogPostAsync(Guid blogPostId)
        {
            return await _managePostsRepository.RejectBlogPostAsync(blogPostId);
        }

        public async Task<BlogPost> SuspendBlogPostAsync(Guid blogPostId)
        {
            return await _managePostsRepository.SuspendBlogPostAsync(blogPostId);
        }
    }
}
