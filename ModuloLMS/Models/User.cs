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

        [Required]
        public List<Course> Courses { get; set; }
    }
}
