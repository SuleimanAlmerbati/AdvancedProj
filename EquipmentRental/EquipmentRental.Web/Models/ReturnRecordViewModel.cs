using System;

namespace EquipmentRental.Web.Models
{
    public class ReturnRecordViewModel
    {
        public int RentalTransactionId { get; set; }
        public string CustomerName { get; set; }
        public string EquipmentName { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public string ReturnCondition { get; set; }
        public decimal? LateReturnFee { get; set; }
        public decimal? AdditionalCharges { get; set; }
        public decimal TotalCharges { get; set; }
        public string PaymentStatus { get; set; }
    }
} 