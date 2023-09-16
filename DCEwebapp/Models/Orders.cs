using System;
using System.ComponentModel.DataAnnotations;

namespace DCEwebapp.Models
{
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int OrderStatus { get; set; }

        [Required]
        public int OrderType { get; set; }

        [Required]
        public Guid OrderBy { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        [Required]
        public DateTime ShippedOn { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
