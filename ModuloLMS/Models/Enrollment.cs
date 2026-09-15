using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloLMS.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))] // Binds Student to the StudentId above and tells EF that this is a foreign key referencing the User table. EF would also be able figure this out without the attribute.
        public User Student { get; set; } = null!; // navigation to student (User)

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!; // navigation to course (Course)

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public string? FinalGrade { get; set; }
    }
}
