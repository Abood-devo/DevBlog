using System.ComponentModel.DataAnnotations;

namespace devBlog.Models
{
    public class BlogPost
    {
        public Guid BlogPostID { get; set; }
        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [StringLength(512)]
        public string Description { get; set; }
        [Required]
        [StringLength(512)]
        public string CoverPhotoUrl { get; set; }
        public bool IsPublished { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Author { get; set; }
        public Guid AuthorID { get; set; }
        public Guid TopicID { get; set; }

        public ICollection<BlogPostTag> BlogPostTags { get; set; } = new List<BlogPostTag>();
    }
}
