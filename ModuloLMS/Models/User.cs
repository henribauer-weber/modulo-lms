using System.ComponentModel.DataAnnotations;

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

        [DataType(DataType.Password), StringLength(64, MinimumLength = 12), Required]
        public string Password { get; set; }

        [Display(Name = "Date of Birth"), DataType(DataType.Date), Required]
        public DateTime DateOfBirth { get; set; }
    }
}
