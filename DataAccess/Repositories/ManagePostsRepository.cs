using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ManagePostsRepository(devBlogContext context) : IManagePostsRepository
    {
        private readonly devBlogContext _context = context;

        public async Task<IEnumerable<BlogPost>> GetPendingBlogPostsAsync()
        {
            return await _context.BlogPost
               .Where(b => !b.IsApproved)
               .ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetApprovedBlogPostsAsync()
        {
            return await _context.BlogPost
                .Where(b => b.IsApproved)
                .ToListAsync();
        }
        public async Task<BlogPost> ApproveBlogPostAsync(Guid blogPostId)
        {
            var blogPost = await _context.BlogPost.FindAsync(blogPostId);
            blogPost.IsApproved = true;
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost> DeleteBlogPostAsync(Guid blogPostId)
        {
            var blogPost = await _context.BlogPost.FindAsync(blogPostId);
            _context.BlogPost.Remove(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost> RejectBlogPostAsync(Guid blogPostId)
        {
            var blogPost = await _context.BlogPost.FindAsync(blogPostId);
            blogPost.IsApproved = false;
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost> SuspendBlogPostAsync(Guid blogPostId)
        {
            var blogPost = await _context.BlogPost.FindAsync(blogPostId);
            blogPost.IsApproved = false;
            await _context.SaveChangesAsync();
            return blogPost;
        }
    }
}
