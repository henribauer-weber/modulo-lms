using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ModuloLMS.Data;

namespace ModuloLMS.Pages.UserPages
{
    public class LoginModel : PageModel
    {
        private readonly ModuloLMSContext _context;

        public LoginModel(ModuloLMSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public class InputModel
        {
            [Required, EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required, DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }

        [BindProperty]
        public InputModel Input { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            // TODO: Get hashed password
            
            var userEntity = await _context.User.FirstOrDefaultAsync(u => u.Email.ToLower() == Input.Email.ToLower() && u.Password == Input.Password);

            if (userEntity == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            // Redirect to dashboard page after login
            return RedirectToPage("/Dashboard");
        }
    }
}
