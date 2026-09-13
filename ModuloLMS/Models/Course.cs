using System.ComponentModel.DataAnnotations;
using System.Numerics;



namespace ModuloLMS.Models
{
    public class Course
    {
        public class ClassTime
        {
            public DateTime StartTime { get; set; }
            public TimeSpan Duration { get; set; }
        }

        [Display(Name = "Course Number"), Required]
        public string CourseNumber { get; set; }

        [Display(Name = "Title"), Required]
        public string CourseTitle { get; set; }

        [Display(Name = "Description"), Required]
        public string CourseDescription { get; set; }

        [Display(Name = "Capacity"), Required]
        public int CourseCapacity { get; set; }

        [Display(Name = "Number of Credits"), Required]
        public int Credits { get; set; }

        [Display(Name = "Class Times"), Required]
        public List<ClassTime> ClassTimes { get; set; }
    }
}
