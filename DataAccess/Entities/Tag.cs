using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Tag
    {
        public Guid TagID { get; set; }
        [Required]
        [StringLength(256)]
        public required string Name { get; set; }

        public ICollection<BlogPostTag> BlogPostTags { get; set; } = new List<BlogPostTag>();
    }
}
