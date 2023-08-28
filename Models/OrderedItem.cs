
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
    public class OrderedItem
    {
        [Key]
        public int Id { get; set; }

       [ ForeignKey("Product")]
        public int ProductsId { get; set; }

        public int ProductsCount { get; set;}
    }
}
