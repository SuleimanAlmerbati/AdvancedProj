using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    public partial class RentalTransaction
    {
        public RentalTransaction()
        {
            Documents = new HashSet<Document>();
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EquipmentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ActualRentalStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpectedReturnDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Deposit { get; set; }
        [StringLength(50)]
        public string PaymentStatus { get; set; } = null!;

        [ForeignKey("CustomerId")]
        [InverseProperty("RentalTransactions")]
        public virtual User Customer { get; set; } = null!;
        [ForeignKey("EquipmentId")]
        [InverseProperty("RentalTransactions")]
        public virtual Equipment Equipment { get; set; } = null!;
        [InverseProperty("RentalTransaction")]
        public virtual ReturnRecord? ReturnRecord { get; set; }
        [InverseProperty("RentalTransaction")]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
