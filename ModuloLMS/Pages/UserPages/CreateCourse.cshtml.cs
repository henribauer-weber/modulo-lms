using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModuloLMS.Pages.UserPages
{
    //[Authorize] // will prevent non-logged in users from accessing page, likely will want in most places
    public class CreateCourseModel : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
