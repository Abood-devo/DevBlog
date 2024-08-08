using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Entities;
using BusinessLogic.Interfaces;

namespace devBlog.Pages.Tags
{
	public class CreateModel : PageModel
    {
		private readonly ITagService _TagService;

		public CreateModel(ITagService blogPostService)
        {
			_TagService = blogPostService;
		}

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tag Tag { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _TagService.CreateTagAsync(Tag);

            return RedirectToPage("./Index");
        }
    }
}
