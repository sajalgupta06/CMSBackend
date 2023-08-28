    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }

        [ForeignKey("OrderedItemsId")]
        public virtual OrderedItem OrderedItems  { get; set; }

        public  int OrderedItemsId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public string? OrderStatus { get; set; }

        [Required]
        public decimal? Total { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
