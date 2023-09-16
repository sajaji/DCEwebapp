using System;
using System.ComponentModel.DataAnnotations;

namespace DCEwebapp.Models
{
    public class Product
    {

        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
