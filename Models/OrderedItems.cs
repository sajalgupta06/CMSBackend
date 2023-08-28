
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
    public class OrderedItems
    {
        [Key]
        public int Id { get; set; }

       [ ForeignKey("ProductsId")]
        public virtual Product Product { get; set; }
        public int ProductsId { get; set; }

        public int ProductsCount { get; set;}
    }
}
