using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public bool? IsVisible { get; set; }

        [ForeignKey("EquipmentId")]
        [InverseProperty("Feedbacks")]
        public virtual Equipment Equipment { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Feedbacks")]
        public virtual User User { get; set; } = null!;
    }
}
