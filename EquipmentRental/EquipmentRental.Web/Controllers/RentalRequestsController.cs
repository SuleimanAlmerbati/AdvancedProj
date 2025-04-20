using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Web.Controllers
{
    public class RentalRequestsController : Controller
    {
        private readonly CourseDBContext _context;

        public RentalRequestsController(CourseDBContext context)
        {
            _context = context;
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
        public IActionResult Approve(int id)
        {
            var request = _context.RentalRequests.Find(id);
            if (request == null) return NotFound();

            request.Status = "Approved";
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Rental request approved.";
            return RedirectToAction("Index");
        }

        // POST: Reject
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var request = _context.RentalRequests.Find(id);
            if (request == null) return NotFound();

            request.Status = "Rejected";
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Rental request rejected.";
            return RedirectToAction("Index");
        }
    }
}
