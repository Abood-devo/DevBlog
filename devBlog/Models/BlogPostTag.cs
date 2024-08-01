namespace devBlog.Models
{
    public class BlogPostTag
    {
        public Guid BlogPostID { get; set; }
        public BlogPost BlogPost { get; set; } = default!;

        public Guid TagID { get; set; }
        public Tag Tag { get; set; } = default!;
    }
}
