using System;
using System.ComponentModel.DataAnnotations;

namespace DCEwebapp.Models
{
    public class Supplier
    {
        [Key]
        public Guid SupplierId { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierName { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
