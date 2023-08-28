using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
  //  [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be atleast 5 characters long ")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is  Required")]
        [EmailAddress(ErrorMessage = "Must be a Valid Email Address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Contact Number is  Required")]
        [RegularExpression(@"^[6-9][0-9]{9}$", ErrorMessage = "Must be a Valid Number")]
        public string ContactNumber { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

      
        public int Status { get; set; }

        public string Role { get; set; } = "USER";



    }
}
