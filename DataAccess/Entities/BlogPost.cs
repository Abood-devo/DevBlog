using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class BlogPost
    {
        public Guid BlogPostID { get; set; }
        [Required]
        [StringLength(256)]
        public required string Title { get; set; }
        [Required]
        public required string Content { get; set; }
        [StringLength(512)]
        public string? Description { get; set; }
        [Required]
        [StringLength(512)]
        public required string CoverPhotoUrl { get; set; }
        public bool IsPublished { get; set; }
		public bool IsApproved { get; set; }
		[DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public required string Author { get; set; }
        public Guid AuthorID { get; set; }
        public ICollection<BlogPostTag> BlogPostTags { get; set; } = new List<BlogPostTag>();
    }
}
