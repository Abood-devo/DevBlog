using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

		public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost)
        {
            return await _blogPostRepository.CreateBlogPostAsync(blogPost);
        }

        public async Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId)
        {
            return await _blogPostRepository.DeleteBlogPostAsync(blogPostId);
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(Guid blogPostId)
        {
            return await _blogPostRepository.GetBlogPostByIdAsync(blogPostId);
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
        {
            return await _blogPostRepository.GetBlogPostsAsync();
        }

        public async Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost)
        {
            return await _blogPostRepository.UpdateBlogPostAsync(blogPost);
        }

        public async Task<IEnumerable<Tag>> GetBlogPostTagsAsync(Guid blogPostId)
        {
            return await _blogPostRepository.GetBlogPostTagsAsync(blogPostId);
        }

        public async Task AddBlogPostTagsAsync(IEnumerable<BlogPostTag> blogPostTags)
        {
            _blogPostRepository.AddBlogPostTags(blogPostTags);
            await _blogPostRepository.SaveChangesAsync();
        }

        public async Task RemoveBlogPostTagsAsync(IEnumerable<BlogPostTag> blogPostTags)
        {
            _blogPostRepository.RemoveBlogPostTags(blogPostTags);
            await _blogPostRepository.SaveChangesAsync();
        }

        public async Task<bool> BlogPostExists(Guid id)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(id);
            return blogPost != null;
        }

		public Task<IEnumerable<BlogPost>> GetApprovedBlogPostsAsync()
		{
			return _blogPostRepository.GetApprovedBlogPostsAsync();
		}

		public Task<IEnumerable<BlogPost>> GetPendingBlogPostsAsync()
		{
            return _blogPostRepository.GetPendingBlogPostsAsync();
		}
        Task IBlogPostService.SaveChangesAsync()
		{
			return _blogPostRepository.SaveChangesAsync();
		}
	}
}
