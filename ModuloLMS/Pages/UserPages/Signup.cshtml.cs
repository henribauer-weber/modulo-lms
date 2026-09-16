using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModuloLMS.Data;
using ModuloLMS.Models;
using System.ComponentModel.DataAnnotations;

namespace ModuloLMS.Pages.UserPages;

public class CreateModel : PageModel
{
    private readonly ModuloLMSContext _context;

    public CreateModel(ModuloLMSContext context)
    {
        _context = context;
    }

    // Receive/preserve return URL
    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public User User { get; set; } = default!;

    [BindProperty]
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(64, MinimumLength = 12, ErrorMessage = "Password must be at least {2} characters.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [BindProperty]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The passwords do not match.")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Password != ConfirmPassword)
        {
            ModelState.AddModelError("ConfirmPassword", "The passwords do not match.");
            return Page();
        }

        bool emailExists = await _context.Users.AnyAsync(u => u.Email.ToLower() == User.Email.ToLower());

        if (emailExists)
        {
            ModelState.AddModelError("User.Email", "This email address is already registered.");
            return Page();
        }

        var age = (DateTime.Today - User.DateOfBirth).TotalDays / 365.25; // Get age in years

        if (age < 16)
        {
            ModelState.AddModelError("User.DateOfBirth", "You must be at least 16 years old to create an account.");
            return Page();
        }

        // TODO: Hash the password before saving to the database
        var Hasher = new PasswordHasher<User>();
        User.PasswordHash = Hasher.HashPassword(User, Password);

        _context.Users.Add(User);
        await _context.SaveChangesAsync();

        // After signup, send user to login page so they can sign in; preserve ReturnUrl so they can continue
        if (!string.IsNullOrEmpty(ReturnUrl))
        {
            return RedirectToPage("/UserPages/Login", new { returnUrl = ReturnUrl });
        }
        // Redirect to Dashboard or Login page after successful signup
        return RedirectToPage("/UserPages/Login");
    }
}
