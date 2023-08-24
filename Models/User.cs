using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
  //  [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Contact Number is required")]
        public string contactNumber { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool status { get; set; }

        public string role { get; set; } 
        
       

    }
     
}
