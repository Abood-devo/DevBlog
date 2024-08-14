using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;

namespace devBlog.Pages.Tags
{
    public class DetailsModel : PageModel
    {
		private readonly ITagService _TagService;

		public DetailsModel(ITagService blogPostService)
		{
			_TagService = blogPostService;
		}

		public TagDTO Tag { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _TagService.GetTagByIdAsync(id.Value);
            if (tag == null)
            {
                return NotFound();
            }
            else
            {
                Tag = tag;
            }
            return Page();
        }
    }
}
