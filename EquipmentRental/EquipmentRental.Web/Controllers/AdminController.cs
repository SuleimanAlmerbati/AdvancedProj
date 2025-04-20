using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;

namespace EquipmentRental.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly CourseDBContext _context;

        public AdminController(CourseDBContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            // Totals
            ViewBag.TotalUsers = _context.Users.Count();
            ViewBag.TotalCategories = _context.Categories.Count();
            ViewBag.TotalEquipment = _context.Equipment.Count();

            // Users by Role
            ViewBag.AdminCount = _context.Users.Count(u => u.Role.ToLower() == "admin");
            ViewBag.ManagerCount = _context.Users.Count(u => u.Role.ToLower() == "manager");
            ViewBag.CustomerCount = _context.Users.Count(u => u.Role.ToLower() == "customer");

            // Equipment by Availability Status
            ViewBag.AvailableCount = _context.Equipment.Count(e => e.AvailabilityStatus.ToLower() == "available");
            ViewBag.RentedCount = _context.Equipment.Count(e => e.AvailabilityStatus.ToLower() == "rented");
            ViewBag.MaintenanceCount = _context.Equipment.Count(e => e.AvailabilityStatus.ToLower() == "maintenance");
            ViewBag.UnavailableCount = _context.Equipment.Count(e => e.AvailabilityStatus.ToLower() == "unavailable");

            // Greet Admin
            ViewBag.AdminName = HttpContext.Session.GetString("UserName");

            return View("~/Views/Admin/Dashboard.cshtml");

        }
    }
}
