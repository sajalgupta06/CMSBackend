using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
    /*[Table("Products")]*/
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

       

        [Required]  
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
    
        public int Status { get; set; }



    }
}
