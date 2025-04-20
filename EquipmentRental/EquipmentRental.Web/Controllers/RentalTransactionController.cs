using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EquipmentLibrary.Model;
using EquipmentRental.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Web.Controllers
{
    //[Authorize(Roles = "Manager")]
    public class RentalTransactionController : Controller
    {
        private readonly CourseDBContext _context;

        public RentalTransactionController(CourseDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string status = "all")
        {
            var query = _context.RentalTransactions
                .Include(r => r.Customer)
                .Include(r => r.Equipment)
                .Include(r => r.ReturnRecord)
                .AsQueryable();

            // Apply filter based on status
            switch (status?.ToLower())
            {
                case "active":
                    query = query.Where(r => r.ReturnRecord == null);
                    break;
                case "returned":
                    query = query.Where(r => r.ReturnRecord != null);
                    break;
                case "pending":
                    query = query.Where(r => r.PaymentStatus.ToLower() == "pending");
                    break;
                case "paid":
                    query = query.Where(r => r.PaymentStatus.ToLower() == "paid");
                    break;
                // "all" or any other value will show all rentals
            }

            var rentals = await query
                .Select(r => new RentalTransactionViewModel
                {
                    Id = r.Id,
                    CustomerName = r.Customer.Name,
                    EquipmentName = r.Equipment.Name,
                    ActualRentalStart = r.ActualRentalStart,
                    ExpectedReturnDate = r.ExpectedReturnDate,
                    ActualReturnDate = r.ReturnRecord != null ? r.ReturnRecord.ActualReturnDate : null,
                    RentalFee = r.RentalFee,
                    PaymentStatus = r.PaymentStatus,
                    IsReturned = r.ReturnRecord != null,
                    ReturnCondition = r.ReturnRecord != null ? r.ReturnRecord.ReturnCondition : null,
                    LateReturnFee = r.ReturnRecord != null ? r.ReturnRecord.LateReturnFee : null,
                    AdditionalCharges = r.ReturnRecord != null ? r.ReturnRecord.AdditionalCharges : null
                })
                .OrderByDescending(r => r.ActualRentalStart)
                .ToListAsync();

            ViewBag.CurrentFilter = status;
            return View(rentals);
        }

        public async Task<IActionResult> Details(int id)
        {
            var rental = await _context.RentalTransactions
                .Include(r => r.Customer)
                .Include(r => r.Equipment)
                    .ThenInclude(e => e.Category)
                .Include(r => r.ReturnRecord)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            var viewModel = new RentalTransactionViewModel
            {
                Id = rental.Id,
                CustomerName = rental.Customer.Name,
                EquipmentName = rental.Equipment.Name,
                EquipmentDescription = rental.Equipment.Description,
                EquipmentCategory = rental.Equipment.Category.Name,
                EquipmentRentalPrice = rental.Equipment.RentalPrice,
                EquipmentCondition = rental.Equipment.ConditionStatus,
                ActualRentalStart = rental.ActualRentalStart,
                ExpectedReturnDate = rental.ExpectedReturnDate,
                ActualReturnDate = rental.ReturnRecord != null ? rental.ReturnRecord.ActualReturnDate : null,
                RentalFee = rental.RentalFee,
                PaymentStatus = rental.PaymentStatus,
                IsReturned = rental.ReturnRecord != null,
                ReturnCondition = rental.ReturnRecord != null ? rental.ReturnRecord.ReturnCondition : null,
                LateReturnFee = rental.ReturnRecord != null ? rental.ReturnRecord.LateReturnFee : null,
                AdditionalCharges = rental.ReturnRecord != null ? rental.ReturnRecord.AdditionalCharges : null
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ProcessReturn(int id)
        {
            var rental = await _context.RentalTransactions
                .Include(r => r.Customer)
                .Include(r => r.Equipment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            var viewModel = new RentalTransactionViewModel
            {
                Id = rental.Id,
                CustomerName = rental.Customer.Name,
                EquipmentName = rental.Equipment.Name,
                ActualRentalStart = rental.ActualRentalStart,
                ExpectedReturnDate = rental.ExpectedReturnDate,
                RentalFee = rental.RentalFee,
                PaymentStatus = rental.PaymentStatus,
                IsReturned = rental.ReturnRecord != null
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessReturn(int id, string returnCondition, decimal? lateReturnFee, decimal? additionalCharges, string notes)
        {
            var rental = await _context.RentalTransactions
                .Include(r => r.Equipment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            // Create return record
            var returnRecord = new ReturnRecord
            {
                RentalTransactionId = id,
                ActualReturnDate = DateTime.Now,
                ReturnCondition = returnCondition,
                LateReturnFee = lateReturnFee,
                AdditionalCharges = additionalCharges
            };

            // Update equipment availability
            rental.Equipment.AvailabilityStatus = "Available";

            // Add return record to database
            _context.ReturnRecords.Add(returnRecord);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Equipment return processed successfully.";
            return RedirectToAction(nameof(Details), new { id });
        }
    }
} 