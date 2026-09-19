using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModuloLMS.Pages.UserPages
{
    [IgnoreAntiforgeryToken]
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            await SignOutAndClearCookiesAsync();
            return RedirectToPage("/UserPages/Login");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await SignOutAndClearCookiesAsync();
            return RedirectToPage("/UserPages/Login");
        }

        private async Task SignOutAndClearCookiesAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
        }
    }
}

