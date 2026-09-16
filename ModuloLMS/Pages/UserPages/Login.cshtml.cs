using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ModuloLMS.Data;
using ModuloLMS.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ModuloLMS.Pages.UserPages
{
    public class LoginModel : PageModel
    {
        private readonly ModuloLMSContext _context;

        public LoginModel(ModuloLMSContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }

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
            //=====================================================================================
            // Validate Inputs and Check with Databse 
            //=====================================================================================
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
            //=====================================================================================


            //=====================================================================================
            // User Authentication and Session Creation 
            //=====================================================================================

            // Create claims and sign in with cookie auth
            var claims = new List<Claim>
            { // Create claims for the user, which are key value pairs that represent the user's identity and roles
                new Claim(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                new Claim(ClaimTypes.Name, userEntity.Email ?? string.Empty),
                new Claim(ClaimTypes.Email, userEntity.Email ?? string.Empty),
                new Claim(ClaimTypes.Role, userEntity.Type == UserType.Instructor ? "Instructor" : "Student")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // Create a claims identity with the claims and specify the authentication scheme
            var principal = new ClaimsPrincipal(identity); // Create a claims principal with the identity, which represents the authenticated user

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false // The authentication cookie lasts until the end of this browser session.
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties); // Sign in the user with the claims principal and authentication properties
            //=====================================================================================


            // If ReturnUrl is provided and is local, redirect back. Otherwise go to dashboard.
            if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
            {
                return LocalRedirect(ReturnUrl);
            }
            // Redirect to dashboard page after login
            return RedirectToPage("/Dashboard"); // TODO: Change this to the actual dashboard page once it's implemented
        }
    }
}
