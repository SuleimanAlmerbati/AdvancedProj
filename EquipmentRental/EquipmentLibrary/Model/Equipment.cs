using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    public partial class Equipment
    {
        public Equipment()
        {
            Feedbacks = new HashSet<Feedback>();
            RentalRequests = new HashSet<RentalRequest>();
            RentalTransactions = new HashSet<RentalTransaction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalPrice { get; set; }
        [StringLength(50)]
        public string AvailabilityStatus { get; set; } = null!;
        [StringLength(50)]
        public string ConditionStatus { get; set; } = null!;
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Equipment")]
        public virtual Category Category { get; set; } = null!;
        [InverseProperty("Equipment")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [InverseProperty("Equipment")]
        public virtual ICollection<RentalRequest> RentalRequests { get; set; }
        [InverseProperty("Equipment")]
        public virtual ICollection<RentalTransaction> RentalTransactions { get; set; }
    }
}
