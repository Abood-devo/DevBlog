using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using BusinessLogic.Interfaces;

namespace devBlog.Pages.Tags
{
	public class DeleteModel : PageModel
    {
		private readonly ITagService _TagService;

		public DeleteModel(ITagService blogPostService)
		{
			_TagService = blogPostService;
		}

		[BindProperty]
        public Tag Tag { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _TagService.GetTagByIdAsync(id.Value);
            if (tag != null)
            {
                Tag = tag;
                await _TagService.DeleteTagAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
