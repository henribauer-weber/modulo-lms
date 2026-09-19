using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using ModuloLMS.Data;
using ModuloLMS.Models;
using static ModuloLMS.Models.Course;

namespace ModuloLMS.Pages.CoursePages
{
    [Authorize(Roles = "Instructor")] // will prevent non-logged in users from accessing page, likely will want in most places
    public class CreateCourseModel : PageModel
    {
        private readonly ModuloLMSContext _context;

        public CreateCourseModel(ModuloLMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        // TODO: migrate to instructor / student child classes
        public User Instructor { get; set; }

        [BindProperty]
        public List<ClassTime> ClassTimes { get; set; } = new();

        public void OnGet()
        {
            
        }

        public IActionResult OnPostDeleteTime(int index)
        {
            ModelState.Clear(); // bandaid fix, move away from this system as possible
            if (index < ClassTimes.Count)
            {
                ClassTimes.RemoveAt(index);
            }
            return Page();
        }

        public IActionResult OnPostAddTime()
        {
            ModelState.Clear(); // bandaid fix, move away from this system as possible
            ClassTimes.Add(new ClassTime());
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            this.Course.ClassTimes = ClassTimes;

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./index");

        }
    }
}
