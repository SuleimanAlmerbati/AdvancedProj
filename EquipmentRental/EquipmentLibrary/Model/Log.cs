using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    public partial class Log
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Action { get; set; }
        [StringLength(50)]
        public string? Source { get; set; }
        public string? Details { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logs")]
        public virtual User? User { get; set; }
    }
}
