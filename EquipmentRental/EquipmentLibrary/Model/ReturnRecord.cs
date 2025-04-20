using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    public partial class ReturnRecord
    {
        [Key]
        public int RentalTransactionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ActualReturnDate { get; set; }
        [StringLength(50)]
        public string? ReturnCondition { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? LateReturnFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AdditionalCharges { get; set; }

        [ForeignKey("RentalTransactionId")]
        [InverseProperty("ReturnRecord")]
        public virtual RentalTransaction RentalTransaction { get; set; } = null!;
    }
}
