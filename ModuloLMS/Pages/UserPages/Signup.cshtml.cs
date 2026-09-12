using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModuloLMS.Models;
using ModuloLMS.Data;

namespace ModuloLMS.Pages.UserPages;

public class CreateModel : PageModel
{
    private readonly ModuloLMSContext _context;

    public CreateModel(ModuloLMSContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public User User { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool emailExists = await _context.User.AnyAsync(u => u.Email.ToLower() == User.Email.ToLower());

        if (emailExists)
        {
            ModelState.AddModelError("User.Email", "This email address is already registered.");
            return Page();
        }

        // TODO: Hash the password before saving to the database

        _context.User.Add(User);
        await _context.SaveChangesAsync();

        // Redirect to Dashboard or Login page after successful signup
        return RedirectToPage("./Index");
    }
}
