using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    public partial class RentalRequest
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RentalStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReturnDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCost { get; set; }
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
        [StringLength(500)]
        public string Reason { get; set; }

        [ForeignKey("EquipmentId")]
        [InverseProperty("RentalRequests")]
        public virtual Equipment Equipment { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("RentalRequests")]
        public virtual User User { get; set; } = null!;
    }
}
