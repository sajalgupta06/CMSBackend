
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
    public class OrderedItem
    {
        [Key]
        public int Id { get; set; } 

        public int ProductsId { get; set; }
        [ForeignKey("ProductsId")]
        public Product? Product { get; set; }

        public string ProductName { get; set; }
        public int ProductsPrice { get; set; }

        public int ProductsCount { get; set;}
    }
}
