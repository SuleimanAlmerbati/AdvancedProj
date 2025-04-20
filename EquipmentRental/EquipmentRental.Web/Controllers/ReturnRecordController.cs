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
    public class ReturnRecordController : Controller
    {
        private readonly CourseDBContext _context;

        public ReturnRecordController(CourseDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string condition = "all")
        {
            var query = _context.ReturnRecords
                .Include(r => r.RentalTransaction)
                    .ThenInclude(rt => rt.Customer)
                .Include(r => r.RentalTransaction)
                    .ThenInclude(rt => rt.Equipment)
                .AsQueryable();

            // Apply filter based on condition
            if (condition != "all")
            {
                query = query.Where(r => r.ReturnCondition.ToLower() == condition.ToLower());
            }

            var returns = await query
                .Select(r => new ReturnRecordViewModel
                {
                    RentalTransactionId = r.RentalTransaction.Id,
                    CustomerName = r.RentalTransaction.Customer.Name,
                    EquipmentName = r.RentalTransaction.Equipment.Name,
                    RentalStartDate = r.RentalTransaction.ActualRentalStart,
                    ExpectedReturnDate = r.RentalTransaction.ExpectedReturnDate,
                    ActualReturnDate = r.ActualReturnDate,
                    ReturnCondition = r.ReturnCondition,
                    LateReturnFee = r.LateReturnFee,
                    AdditionalCharges = r.AdditionalCharges,
                    TotalCharges = (r.LateReturnFee ?? 0) + (r.AdditionalCharges ?? 0),
                    PaymentStatus = r.RentalTransaction.PaymentStatus
                })
                .OrderByDescending(r => r.ActualReturnDate)
                .ToListAsync();

            ViewBag.CurrentFilter = condition;
            return View(returns);
        }

        public async Task<IActionResult> Create(int id)
        {
            var rental = await _context.RentalTransactions
                .Include(rt => rt.Customer)
                .Include(rt => rt.Equipment)
                .FirstOrDefaultAsync(rt => rt.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            var model = new ReturnRecordViewModel
            {
                RentalTransactionId = rental.Id,
                CustomerName = rental.Customer.Name,
                EquipmentName = rental.Equipment.Name,
                RentalStartDate = rental.ActualRentalStart,
                ExpectedReturnDate = rental.ExpectedReturnDate,
                ActualReturnDate = DateTime.Now // Default to current date
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReturnRecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rental = await _context.RentalTransactions
                    .Include(rt => rt.Equipment)
                    .FirstOrDefaultAsync(rt => rt.Id == model.RentalTransactionId);

                if (rental == null)
                {
                    return NotFound();
                }

                var returnRecord = new ReturnRecord
                {
                    RentalTransactionId = rental.Id,
                    ActualReturnDate = model.ActualReturnDate,
                    ReturnCondition = model.ReturnCondition,
                    LateReturnFee = model.LateReturnFee,
                    AdditionalCharges = model.AdditionalCharges
                };

                // Update equipment status based on return condition
                rental.Equipment.AvailabilityStatus = model.ReturnCondition.ToLower() switch
                {
                    "excellent" or "good" => "Available",
                    "fair" or "poor" => "Maintenance",
                    "damaged" => "Repair",
                    _ => "Maintenance"
                };

                // Update equipment condition status
                rental.Equipment.ConditionStatus = model.ReturnCondition;

                _context.ReturnRecords.Add(returnRecord);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Return processed successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
} 