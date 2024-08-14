using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class BlogPostRepository(devBlogContext context) : IBlogPostRepository
    {
        private readonly devBlogContext _context = context;

        public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost)
        {
            _context.BlogPost.Add(blogPost);
            
            // initialize the creation and last modified date
            blogPost.CreationDate = DateTime.Now;
            blogPost.LastModifiedDate = DateTime.Now;
            blogPost.IsApproved = false;
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId)
        {
            var blogPost = await _context.BlogPost.FindAsync(blogPostId);
            if (blogPost == null) return null;

            _context.BlogPost.Remove(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(Guid blogPostId)
        {
            return await _context.BlogPost
                .Include(bp => bp.BlogPostTags)
                .ThenInclude(bt => bt.Tag)
                .FirstOrDefaultAsync(bp => bp.BlogPostID == blogPostId);
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
        {
            return await _context.BlogPost.ToListAsync();
        }
        public async Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost)
        {
            // Retrieve the existing blog post from the database
            var existingBlogPost = await _context.BlogPost
                .Include(bp => bp.BlogPostTags) // If you need to update tags
                .FirstOrDefaultAsync(bp => bp.BlogPostID == blogPost.BlogPostID);

            if (existingBlogPost == null)
            {
                return null;
            }

            // Update properties
            existingBlogPost.Title = blogPost.Title;
            existingBlogPost.Content = blogPost.Content;
            existingBlogPost.LastModifiedDate = DateTime.Now;
            existingBlogPost.IsApproved = false;

            // Update tags (optional)
            if (blogPost.BlogPostTags != null)
            {
                _context.BlogPostTag.RemoveRange(existingBlogPost.BlogPostTags);
                existingBlogPost.BlogPostTags = blogPost.BlogPostTags;
            }

            await _context.SaveChangesAsync();
            return existingBlogPost;
        }
        public async Task<IEnumerable<Tag>> GetBlogPostTagsAsync(Guid blogPostId)
        {
            return await _context.BlogPostTag
                .Where(bpt => bpt.BlogPostID == blogPostId)
                .Select(bpt => bpt.Tag)
                .ToListAsync();
        }

        public async Task RemoveBlogPostTags(IEnumerable<BlogPostTag> blogPostTags)
        {
            _context.BlogPostTag.RemoveRange(blogPostTags);
            await _context.SaveChangesAsync();
        }

        public async Task AddBlogPostTags(IEnumerable<BlogPostTag> blogPostTags)
        {
            _context.BlogPostTag.AddRange(blogPostTags);
            await _context.SaveChangesAsync();
        }
	}
}
