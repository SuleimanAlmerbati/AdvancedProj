using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    public partial class Log
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [StringLength(255)]
        public string Action { get; set; } = null!;
        [StringLength(100)]
        public string Source { get; set; } = null!;
        [StringLength(255)]
        public string Details { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logs")]
        public virtual User User { get; set; } = null!;
    }
}
