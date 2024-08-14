using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;

namespace devBlog.Pages.Tags
{
    public class EditModel : PageModel
    {
		private readonly ITagService _TagService;

		public EditModel(ITagService blogPostService)
		{
			_TagService = blogPostService;
		}

		[BindProperty]
        public TagDTO Tag { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag =  await _TagService.GetTagByIdAsync(id.Value);
            if (tag == null)
            {
                return NotFound();
            }
            Tag = tag;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
				await _TagService.UpdateTagAsync(Tag);
			}
			catch (DbUpdateConcurrencyException)
            {
                if (!await _TagService.TagExists(Tag.TagID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
