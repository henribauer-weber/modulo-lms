using System.ComponentModel.DataAnnotations;
using System.Numerics;

public enum DayOfWeek { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

namespace ModuloLMS.Models
{
    public class Course
    {
        public class ClassTime
        {
            public DayOfWeek DayOfWeek { get; set; }
            public TimeOnly StartTime { get; set; }
            public TimeOnly EndTime { get; set; }
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
