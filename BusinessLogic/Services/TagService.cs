using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using BusinessLogic.Extensions;
using BusinessLogic.DTOs;

namespace BusinessLogic.Services
{
	public class TagService(ITagRepository tagRepository) : ITagService
	{
		private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<Tag> CreateTagAsync(TagDTO tagDTO)
		{
			var tag = tagDTO.ToEntity();
			return await _tagRepository.CreateTagAsync(tag);
		}

		public async Task<TagDTO> DeleteTagAsync(Guid tagId)
		{
			var tag = await _tagRepository.GetTagByIdAsync(tagId);
			return tag.ToDTO();
		}

		public async Task<IEnumerable<TagDTO>> GetAllTagsAsync()
		{
			var tags = await _tagRepository.GetAllTagsAsync();
			return tags.Select(t => t.ToDTO()).ToList();
		}

		public async Task<TagDTO> GetTagByIdAsync(Guid tagId)
		{
			var tag = await _tagRepository.GetTagByIdAsync(tagId);
			return tag.ToDTO();
		}

		public async Task<bool> TagExists(Guid id)
		{
			var tag = await _tagRepository.GetTagByIdAsync(id);
			return tag != null;
		}

		public async Task<Tag> UpdateTagAsync(TagDTO tagDTO)
		{
			var tag = tagDTO.ToEntity();
			return await _tagRepository.UpdateTagAsync(tag);
		}
	}
}
