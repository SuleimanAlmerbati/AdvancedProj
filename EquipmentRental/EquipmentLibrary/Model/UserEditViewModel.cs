using System.ComponentModel.DataAnnotations;

namespace EquipmentLibrary.Model
{
    public class UserEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Name must contain letters only.")]
        public string Name { get; set; } = null!;

        [StringLength(100)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        public string? PasswordHash { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } = null!;
    }
} 