using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ModuloLMS.Data;
using ModuloLMS.Models;

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
            
            // Get the user associated with this email
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == Input.Email.ToLower());

            var Hasher = new PasswordHasher<User>();

            if (userEntity == null || Hasher.VerifyHashedPassword(userEntity, userEntity.PasswordHash, Input.Password) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            // Redirect to dashboard page after login
<<<<<<< Updated upstream
            return RedirectToPage("/Dashboard");
=======
            return RedirectToPage("/Index");
>>>>>>> Stashed changes
        }
    }
}
