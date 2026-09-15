using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public enum UserType { Student, Instructor };

namespace ModuloLMS.Models
{
    public class User
    {
        public int Id { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Display(Name = "First Name"), StringLength(40, MinimumLength = 1), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), StringLength(40, MinimumLength = 1), Required]
        public string LastName { get; set; }

        [BindNever, ValidateNever]
        public string PasswordHash { get; set; } = string.Empty;

        [Display(Name = "Date of Birth"), DataType(DataType.Date), Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Account Type"), Required]
        public UserType Type { get; set; }


        // Everything below this is for navigation and is not stored in the database. EF will use this to create relationships between tables.

        // enrollments for this user (if student)
        public List<Enrollment> Enrollments { get; set; } = new();

        // courses this user teaches (if instructor)
        public List<Course> CoursesTaught { get; set; } = new();
    }
}
