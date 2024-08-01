using System.ComponentModel.DataAnnotations;

namespace devBlog.Models
{
    public class Tag
    {
        public Guid TagID { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public ICollection<BlogPostTag> BlogPostTags { get; set; } = new List<BlogPostTag>();
    }
}
