using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloLMS.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public User Student { get; set; } = null!; // navigation to student (User)

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!; // navigation to course (Course)

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public string? FinalGrade { get; set; }
    }
}
