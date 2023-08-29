using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;

namespace CMSBackend.Models
{
    /*[Table("Products")]*/
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }


        [Required]  
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        public int Status { get; set; } = 0;



    }
}
