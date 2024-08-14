using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace BusinessLogic.Interfaces
{
	public interface IBlogPostService
    {
        Task<BlogPost> CreateBlogPostAsync(BlogPostDTO blogPostDTO);
        Task<BlogPostDTO> DeleteBlogPostAsync(Guid blogPostId);
        Task<BlogPostDTO> GetBlogPostByIdAsync(Guid blogPostId);
        Task<IEnumerable<BlogPostDTO>> GetBlogPostsAsync();
        Task<BlogPost> UpdateBlogPostAsync(BlogPostDTO blogPostDTO);
        Task<IEnumerable<TagDTO>> GetBlogPostTagsAsync(Guid blogPostId);
        Task AddBlogPostTagsAsync(IEnumerable<BlogPostTagDTO> blogPostTagsDTO);
        Task RemoveBlogPostTagsAsync(IEnumerable<BlogPostTagDTO> blogPostTagsDTO);
        Task<bool> BlogPostExists(Guid id);
	}
}
