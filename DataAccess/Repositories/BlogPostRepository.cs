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
            _context.Entry(blogPost).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _context.Tag.ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetBlogPostTagsAsync(Guid blogPostId)
        {
            return await _context.BlogPostTag
                .Where(bpt => bpt.BlogPostID == blogPostId)
                .Select(bpt => bpt.Tag)
                .ToListAsync();
        }

        public void RemoveBlogPostTags(IEnumerable<BlogPostTag> blogPostTags)
        {
            _context.BlogPostTag.RemoveRange(blogPostTags);
        }

        public void AddBlogPostTags(IEnumerable<BlogPostTag> blogPostTags)
        {
            _context.BlogPostTag.AddRange(blogPostTags);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

		public async Task<IEnumerable<BlogPost>> GetPendingBlogPostsAsync()
		{
			 return await _context.BlogPost
			    .Where(b => !b.IsApproved && b.IsPublished)
			    .ToListAsync();
		}

		public async Task<IEnumerable<BlogPost>> GetApprovedBlogPostsAsync()
		{
		    return await _context.BlogPost
				.Where(b => b.IsApproved)
				.ToListAsync();
		}
	}
}
