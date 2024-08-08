using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class devBlogContext : DbContext
    {
        public devBlogContext(DbContextOptions<devBlogContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; } = default!;
        public DbSet<Tag> Tag { get; set; } = default!;
        public DbSet<BlogPostTag> BlogPostTag { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between BlogPost and Tag through BlogPostTag
            modelBuilder.Entity<BlogPostTag>()
                .HasKey(bpt => new { bpt.BlogPostID, bpt.TagID });

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bpt => bpt.BlogPost)
                .WithMany(bp => bp.BlogPostTags)
                .HasForeignKey(bpt => bpt.BlogPostID);

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bpt => bpt.Tag)
                .WithMany(t => t.BlogPostTags)
                .HasForeignKey(bpt => bpt.TagID);
        }
    }
}
