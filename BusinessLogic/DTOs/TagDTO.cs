using DataAccess.Entities;

namespace BusinessLogic.DTOs
{
    public class TagDTO
    {
        public Guid TagID { get; set; }
        public required string Name { get; set; }
        public ICollection<BlogPostTag> BlogPostTags { get; set; } = [];
    }
}
