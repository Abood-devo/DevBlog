using DataAccess.Entities;
using DataAccess.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;
using BusinessLogic.Extensions;

namespace BusinessLogic.Services
{
    public class BlogPostService(IBlogPostRepository blogPostRepository) : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;

        public async Task<BlogPost> CreateBlogPostAsync(BlogPostDTO blogPostDTO)
        {
            var blogPost = blogPostDTO.ToEntity();
            return await _blogPostRepository.CreateBlogPostAsync(blogPost);
        }

        public async Task<BlogPostDTO> DeleteBlogPostAsync(Guid blogPostId)
        {
            var blogPost = await _blogPostRepository.DeleteBlogPostAsync(blogPostId);
            return blogPost.ToDTO();
        }

        public async Task<BlogPostDTO> GetBlogPostByIdAsync(Guid blogPostId)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(blogPostId);
            return blogPost.ToDTO();
        }

        public async Task<IEnumerable<BlogPostDTO>> GetBlogPostsAsync()
        {
            var blogPosts = await _blogPostRepository.GetBlogPostsAsync();
            return blogPosts.Select(bp => 
            { 
                return bp.ToDTO();
            }).ToList();
        }

        public async Task<BlogPost> UpdateBlogPostAsync(BlogPostDTO blogPostDTO)
        {
            var blogPost = blogPostDTO.ToEntity();
            return await _blogPostRepository.UpdateBlogPostAsync(blogPost);
        }

        public async Task<IEnumerable<TagDTO>> GetBlogPostTagsAsync(Guid blogPostId)
        {
            var blogPostsTags = await _blogPostRepository.GetBlogPostTagsAsync(blogPostId);
            return blogPostsTags.Select(bpt => 
            {
                return bpt.ToDTO();
            }).ToList();
        }

        public async Task AddBlogPostTagsAsync(IEnumerable<BlogPostTagDTO> blogPostTagsDTO)
        {
            var blogPostTags = blogPostTagsDTO.Select(bpt => 
            {
                return bpt.ToEntity();
            }).ToList();
            await _blogPostRepository.AddBlogPostTags(blogPostTags);
        }

        public async Task RemoveBlogPostTagsAsync(IEnumerable<BlogPostTagDTO> blogPostTagsDTO)
        {
            var blogPostTags = blogPostTagsDTO.Select(bpt => 
            {
                return bpt.ToEntity();
            }).ToList();
            await _blogPostRepository.RemoveBlogPostTags(blogPostTags);
        }

        public async Task<bool> BlogPostExists(Guid id)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(id);
            return blogPost != null;
        }
	}
}
