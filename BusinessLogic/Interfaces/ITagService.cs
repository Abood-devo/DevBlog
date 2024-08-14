using BusinessLogic.DTOs;
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
		Task<IEnumerable<TagDTO>> GetAllTagsAsync();
		Task<TagDTO> GetTagByIdAsync(Guid tagId);
		Task<Tag> CreateTagAsync(TagDTO tagDTO);
		Task<Tag> UpdateTagAsync(TagDTO tagDTO);
		Task<TagDTO> DeleteTagAsync(Guid tagId);
		Task<bool> TagExists(Guid id);
	}
}
