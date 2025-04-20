using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;
using Microsoft.EntityFrameworkCore;
using EquipmentRental.Web.Services;

namespace EquipmentRental.Web.Controllers
{
    public class RentalRequestsController : Controller
    {
        private readonly CourseDBContext _context;
        private readonly LoggingService _loggingService;

        public RentalRequestsController(CourseDBContext context, LoggingService loggingService)
        {
            _context = context;
            _loggingService = loggingService;
        }

        // List all requests for manager
        public IActionResult Index()
        {
            var requests = _context.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .OrderByDescending(r => r.Id)
                .ToList();

            return View(requests);
        }

        // POST: Approve
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var rentalRequest = await _context.RentalRequests
                .Include(r => r.Equipment)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rentalRequest == null)
            {
                return NotFound();
            }

            rentalRequest.Status = "Approved";
            _context.Update(rentalRequest);

            // Create rental transaction
            var rentalTransaction = new RentalTransaction
            {
                CustomerId = rentalRequest.UserId,
                EquipmentId = rentalRequest.EquipmentId,
                ActualRentalStart = DateTime.Now,
                ExpectedReturnDate = rentalRequest.ReturnDate,
                RentalFee = rentalRequest.TotalCost,
                PaymentStatus = "Pending"
            };

            _context.RentalTransactions.Add(rentalTransaction);
            await _context.SaveChangesAsync();

            // Log the approval
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            await _loggingService.LogRentalRequestAsync(userId, rentalRequest.Equipment.Name, "Approved");
            await _loggingService.LogRentalAsync(userId, rentalRequest.Equipment.Name, "Pending");

            TempData["SuccessMessage"] = "Rental request approved successfully.";
            return RedirectToAction(nameof(Index));
        }

        // POST: Reject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var rentalRequest = await _context.RentalRequests
                .Include(r => r.Equipment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rentalRequest == null)
            {
                return NotFound();
            }

            rentalRequest.Status = "Rejected";
            _context.Update(rentalRequest);
            await _context.SaveChangesAsync();

            // Log the rejection
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            await _loggingService.LogRentalRequestAsync(userId, rentalRequest.Equipment.Name, "Rejected");

            TempData["SuccessMessage"] = "Rental request rejected successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
