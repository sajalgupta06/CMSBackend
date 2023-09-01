using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;

namespace CMSBackend.Models
{
    /*[Table("Products")]*/
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public   Category? Category { get; set; }


        [Required]  
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
    
        public int Status { get; set; }

        public string Image { get; set; }



    }
}
