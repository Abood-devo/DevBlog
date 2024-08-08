using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface ITagService
	{
		Task<IEnumerable<Tag>> GetAllTagsAsync();
		Task<Tag> GetTagByIdAsync(Guid tagId);
		Task<Tag> CreateTagAsync(Tag tag);
		Task<Tag> UpdateTagAsync(Tag tag);
		Task<Tag> DeleteTagAsync(Guid tagId);
		Task<bool> TagExists(Guid id);
	}
}
