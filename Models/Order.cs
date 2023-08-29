    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }

       
        public OrderedItem[] OrderedItems { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public string? OrderStatus { get; set; }

        [Required]
        public float? Total { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
