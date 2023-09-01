    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace CMSBackend.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }

       
        public ICollection<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();

        public int UserId { get; set; }
        [ForeignKey("UserId")] 
        public User? User { get; set; }

        public string UserName { get; set; } = string.Empty;


        public string? OrderStatus { get; set; }

        [Required]
        public float? Total { get; set; }
        public string PaymentMethod { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
