using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EquipmentLibrary.Model;
using EquipmentRental.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace EquipmentRental.Web.Controllers
{
    //[Authorize(Roles = "Manager")]
    public class ManagerDashboardController : Controller
    {
        private readonly CourseDBContext _context;

        public ManagerDashboardController(CourseDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ManagerDashboardViewModel();

            // Rental Requests Statistics
            var requests = await _context.RentalRequests.ToListAsync();
            viewModel.TotalRentalRequests = requests.Count;
            viewModel.PendingRequests = requests.Count(r => r.Status == "Pending");
            viewModel.ApprovedRequests = requests.Count(r => r.Status == "Approved");
            viewModel.RejectedRequests = requests.Count(r => r.Status == "Rejected");

            // Active Rentals
            var activeRentals = await _context.RentalTransactions
                .Include(r => r.ReturnRecord)
                .Where(r => r.ReturnRecord == null)
                .ToListAsync();
            
            viewModel.ActiveRentals = activeRentals.Count;
            viewModel.OverdueRentals = activeRentals.Count(r => r.ExpectedReturnDate < DateTime.Now);

            // Returns Statistics
            var returns = await _context.ReturnRecords.ToListAsync();
            viewModel.TotalReturns = returns.Count;
            viewModel.ReturnsThisMonth = returns.Count(r => r.ActualReturnDate.Month == DateTime.Now.Month);
            viewModel.TotalLateFees = returns.Sum(r => r.LateReturnFee ?? 0);

            // Equipment Statistics
            var equipment = await _context.Equipment.ToListAsync();
            viewModel.TotalEquipment = equipment.Count;
            viewModel.AvailableEquipment = equipment.Count(e => e.AvailabilityStatus == "Available");
            viewModel.RentedEquipment = equipment.Count(e => e.AvailabilityStatus == "Rented");
            viewModel.MaintenanceEquipment = equipment.Count(e => e.AvailabilityStatus == "Maintenance");
            viewModel.RepairEquipment = equipment.Count(e => e.AvailabilityStatus == "Repair");

            // Recent Activity
            var recentRequests = await _context.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .OrderByDescending(r => r.Id)
                .Take(5)
                .Select(r => new RecentActivityViewModel
                {
                    Type = "Request",
                    Description = $"Rental request for {r.Equipment.Name}",
                    CustomerName = r.User.Name,
                    EquipmentName = r.Equipment.Name,
                    Date = r.RentalStartDate,
                    Status = r.Status
                })
                .ToListAsync();

            var recentRentals = await _context.RentalTransactions
                .Include(r => r.Customer)
                .Include(r => r.Equipment)
                .OrderByDescending(r => r.ActualRentalStart)
                .Take(5)
                .Select(r => new RecentActivityViewModel
                {
                    Type = "Rental",
                    Description = $"Equipment rented: {r.Equipment.Name}",
                    CustomerName = r.Customer.Name,
                    EquipmentName = r.Equipment.Name,
                    Date = r.ActualRentalStart,
                    Status = r.PaymentStatus
                })
                .ToListAsync();

            var recentReturns = await _context.ReturnRecords
                .Include(r => r.RentalTransaction)
                    .ThenInclude(rt => rt.Customer)
                .Include(r => r.RentalTransaction)
                    .ThenInclude(rt => rt.Equipment)
                .OrderByDescending(r => r.ActualReturnDate)
                .Take(5)
                .Select(r => new RecentActivityViewModel
                {
                    Type = "Return",
                    Description = $"Equipment returned: {r.RentalTransaction.Equipment.Name}",
                    CustomerName = r.RentalTransaction.Customer.Name,
                    EquipmentName = r.RentalTransaction.Equipment.Name,
                    Date = r.ActualReturnDate,
                    Status = r.ReturnCondition
                })
                .ToListAsync();

            viewModel.RecentActivities = recentRequests
                .Concat(recentRentals)
                .Concat(recentReturns)
                .OrderByDescending(a => a.Date)
                .Take(10)
                .ToList();

            return View(viewModel);
        }
    }
}
