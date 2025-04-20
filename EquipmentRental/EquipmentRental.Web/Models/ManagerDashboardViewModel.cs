using System;
using System.Collections.Generic;

namespace EquipmentRental.Web.Models
{
    public class ManagerDashboardViewModel
    {
        // Rental Requests Statistics
        public int TotalRentalRequests { get; set; }
        public int PendingRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int RejectedRequests { get; set; }

        // Active Rentals
        public int ActiveRentals { get; set; }
        public int OverdueRentals { get; set; }

        // Returns Statistics
        public int TotalReturns { get; set; }
        public int ReturnsThisMonth { get; set; }
        public decimal TotalLateFees { get; set; }

        // Equipment Statistics
        public int TotalEquipment { get; set; }
        public int AvailableEquipment { get; set; }
        public int RentedEquipment { get; set; }
        public int MaintenanceEquipment { get; set; }
        public int RepairEquipment { get; set; }

        // Recent Activity
        public List<RecentActivityViewModel> RecentActivities { get; set; } = new List<RecentActivityViewModel>();
    }

    public class RecentActivityViewModel
    {
        public string Type { get; set; } // "Request", "Rental", "Return"
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string EquipmentName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
} 