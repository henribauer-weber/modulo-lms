using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ModuloLMS.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public class CourseCardItem
        {
            public string CourseNumber { get; set; } = string.Empty;
            public string CourseTitle { get; set; } = string.Empty;
            public string Instructor { get; set; } = string.Empty;
            public string Time { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;

        }

        public int NumberOfCourses { get; set; }
        public List<CourseCardItem> EnrolledCourses { get; set; } = new();

        public void OnGet()
        {
            EnrolledCourses = new List<CourseCardItem>
            {
                new CourseCardItem
                {
                    CourseNumber = "CS 3750",
                    CourseTitle = "Software Engineering II",
                    Instructor = "John Doe",
                    Time = "MWF 10:30 AM - 11:20 AM",
                    Location = "NOORDA Rm 302"
                },
                new CourseCardItem
                {
                    CourseNumber = "CS 3100",
                    CourseTitle = "Operating Systems",
                    Instructor = "Jane doe",
                    Time = "TR 1:00 PM - 2:15 PM",
                    Location = "Science Lab Rm 115"
                },
                new CourseCardItem
                {
                    CourseNumber = "test",
                    CourseTitle = "test",
                    Instructor = "test",
                    Time = "MWF 10:30 AM - 11:20 AM",
                    Location = "Online"
                },
                new CourseCardItem
                {
                    CourseNumber = "MATH 2250",
                    CourseTitle = "Mathematics",
                    Instructor = "test",
                    Time = "MWF 10:30 AM - 11:20 AM",
                    Location = "Traci Hall Rm 204"
                }
            };
            NumberOfCourses = EnrolledCourses.Count;
        }






    }
}
