using DataAccess.Entities;

namespace DataAccess.Interfaces
{
	public interface ITagRepository
	{
		Task<IEnumerable<Tag>> GetAllTagsAsync();
		Task<Tag> GetTagByIdAsync(Guid tagId);
		Task<Tag> CreateTagAsync(Tag tag);
		Task<Tag> UpdateTagAsync(Tag tag);
		Task<Tag> DeleteTagAsync(Guid tagId);
	}
}
