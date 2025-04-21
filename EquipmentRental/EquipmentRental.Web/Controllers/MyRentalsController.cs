using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EquipmentRental.Web.Models;
using EquipmentLibrary.Model;
using System.Security.Claims;

namespace EquipmentRental.Web.Controllers
{
    //[Authorize]
    public class MyRentalsController : Controller
    {
        private readonly CourseDBContext _context;

        public MyRentalsController(CourseDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string status = "all")
        {
            //var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var query = _context.RentalRequests
                .Include(r => r.Equipment)
                .Where(r => r.UserId == userId);

            // Apply filter
            if (status != "all")
            {
                query = query.Where(r => r.Status == status);
            }

            var rentals = await query
                .OrderByDescending(r => r.RentalStartDate)
                .Select(r => new MyRentalsViewModel
                {
                    Id = r.Id,
                    EquipmentName = r.Equipment.Name,
                    EquipmentDescription = r.Equipment.Description,
                    RentalPrice = r.Equipment.RentalPrice,
                    RentalStartDate = r.RentalStartDate,
                    ReturnDate = r.ReturnDate,
                    TotalCost = r.TotalCost,
                    Status = r.Status,
                    Reason = r.Reason
                })
                .ToListAsync();

            ViewBag.CurrentFilter = status;
            return View(rentals);
        }
    }
} 