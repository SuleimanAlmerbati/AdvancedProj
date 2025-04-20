using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    public partial class Document
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string? FileName { get; set; }
        [StringLength(50)]
        public string? FileType { get; set; }
        [StringLength(255)]
        public string? StoragePath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UploadDate { get; set; }
        public int UploadedByUserId { get; set; }
        public int? RentalTransactionId { get; set; }

        [ForeignKey("RentalTransactionId")]
        [InverseProperty("Documents")]
        public virtual RentalTransaction? RentalTransaction { get; set; }
        [ForeignKey("UploadedByUserId")]
        [InverseProperty("Documents")]
        public virtual User UploadedByUser { get; set; } = null!;
    }
}
