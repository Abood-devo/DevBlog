using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace devBlog.Pages
{
	public class IndexModel(ILogger<IndexModel> logger) : PageModel
	{
		private readonly ILogger<IndexModel> _logger = logger;

        public void OnGet()
		{

		}

		public IActionResult OnGetSetCulture(string culture, string? returnUrl = null)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);

			return LocalRedirect(returnUrl ?? "/");
		}
	}
}
