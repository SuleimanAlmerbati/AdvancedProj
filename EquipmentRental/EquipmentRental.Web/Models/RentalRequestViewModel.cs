using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Web.Models
{
    public class RentalRequestViewModel
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal RentalPrice { get; set; }

        [Required(ErrorMessage = "Please select a start date")]
        [Display(Name = "Rental Start Date")]
        [DataType(DataType.Date)]
        public DateTime RentalStartDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Please select a return date")]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; } = DateTime.Today.AddDays(1);

        [Required(ErrorMessage = "Please enter a reason for rental")]
        [Display(Name = "Reason for Rental")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters")]
        public string Reason { get; set; }

        public decimal TotalCost { get; set; }

        public decimal CalculateTotalCost()
        {
            var days = (ReturnDate - RentalStartDate).Days;
            return days * RentalPrice;
        }
    }
} 