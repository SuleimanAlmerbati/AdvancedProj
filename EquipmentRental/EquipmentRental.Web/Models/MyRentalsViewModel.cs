using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Web.Models
{
    public class MyRentalsViewModel
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal RentalPrice { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string CurrentFilter { get; set; }
    }
} 