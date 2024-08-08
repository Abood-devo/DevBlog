using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
	public class TagService : ITagService
	{
		private readonly ITagRepository _tagRepository;

		public TagService(ITagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		public async Task<Tag> CreateTagAsync(Tag tag)
		{
			return await _tagRepository.CreateTagAsync(tag);
		}

		public async Task<Tag> DeleteTagAsync(Guid tagId)
		{
			return await _tagRepository.DeleteTagAsync(tagId);
		}

		public async Task<IEnumerable<Tag>> GetAllTagsAsync()
		{
			return await _tagRepository.GetAllTagsAsync();
		}

		public async Task<Tag> GetTagByIdAsync(Guid tagId)
		{
			return await _tagRepository.GetTagByIdAsync(tagId);
		}

		public async Task<bool> TagExists(Guid id)
		{
			var tag = await _tagRepository.GetTagByIdAsync(id);
			return tag != null;
		}

		public async Task<Tag> UpdateTagAsync(Tag tag)
		{
			return await _tagRepository.UpdateTagAsync(tag);
		}
	}
}
