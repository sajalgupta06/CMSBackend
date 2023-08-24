using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBackend.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }

        [ForeignKey("Products")]
        public Product[] Products { get; set; }

        [ForeignKey("User")]
        public User User { get; set; }

        public string orderStatus { get; set; }

        [Required]
        public string paymentMethod { get; set; }
        public float total { get; set; }
        public DateAndTime createdBy { get; set; }

    }
}
