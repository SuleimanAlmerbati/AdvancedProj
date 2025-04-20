using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EquipmentLibrary.Model
{
    [Index("Email", Name = "UQ__Users__A9D10534BB7F0413", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Documents = new HashSet<Document>();
            Feedbacks = new HashSet<Feedback>();
            Logs = new HashSet<Log>();
            Notifications = new HashSet<Notification>();
            RentalRequests = new HashSet<RentalRequest>();
            RentalTransactions = new HashSet<RentalTransaction>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Name must contain letters only.")]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        public string PasswordHash { get; set; } = null!;
        [StringLength(50)]

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } = null!;

        [InverseProperty("UploadedByUser")]
        public virtual ICollection<Document> Documents { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Log> Logs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RentalRequest> RentalRequests { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<RentalTransaction> RentalTransactions { get; set; }
    }
}
