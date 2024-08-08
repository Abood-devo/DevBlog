using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
	public class TagRepository(devBlogContext context) : ITagRepository
	{
		private readonly devBlogContext _context = context;

		public async Task<Tag> CreateTagAsync(Tag tag)
		{
			_context.Tag.Add(tag);
			await _context.SaveChangesAsync();
			return tag;
		}

		public async Task<Tag> DeleteTagAsync(Guid tagId)
		{
			Tag? tag = await _context.Tag.FindAsync(tagId);
			if (tag == null) return null;
			
			_context.Tag.Remove(tag);
			await _context.SaveChangesAsync();
			return tag;
		}

		public async Task<IEnumerable<Tag>> GetAllTagsAsync()
		{
			return await _context.Tag.ToListAsync();
		}

		public async Task<Tag> GetTagByIdAsync(Guid tagId)
		{
			return await _context.Tag.FindAsync(tagId);
		}

		public async Task<Tag> UpdateTagAsync(Tag tag)
		{
			_context.Entry(tag).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return tag;
		}
	}
}
