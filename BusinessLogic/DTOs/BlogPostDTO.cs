
namespace BusinessLogic.DTOs
{
    public class BlogPostDTO
    {
        public Guid BlogPostID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public required string CoverPhotoUrl { get; set; }
        public required string Author { get; set; }
        public Guid AuthorID { get; set; }
        public bool IsPublished { get; set; }
        public bool IsApproved { get; set; }
        public ICollection<BlogPostTagDTO> BlogPostTags { get; set; } = [];
    }
}
