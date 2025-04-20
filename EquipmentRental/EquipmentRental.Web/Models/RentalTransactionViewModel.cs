using System;

namespace EquipmentRental.Web.Models
{
    public class RentalTransactionViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public string EquipmentCategory { get; set; }
        public decimal EquipmentRentalPrice { get; set; }
        public string EquipmentCondition { get; set; }
        public DateTime ActualRentalStart { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal RentalFee { get; set; }
        public string PaymentStatus { get; set; }
        public bool IsReturned { get; set; }
        public string ReturnCondition { get; set; }
        public decimal? LateReturnFee { get; set; }
        public decimal? AdditionalCharges { get; set; }
    }
} 