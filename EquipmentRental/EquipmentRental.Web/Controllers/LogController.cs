using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EquipmentRental.Web.Models;
using EquipmentLibrary.Model;

namespace EquipmentRental.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class LogController : Controller
    {
        private readonly CourseDBContext _context;

        public LogController(CourseDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string actionType = "all")
        {
            IQueryable<Log> query = _context.Logs
                .Include(l => l.User)
                .OrderByDescending(l => l.Timestamp);

            if (actionType != "all")
            {
                query = query.Where(l => l.Action == actionType);
            }

            var logs = await query
                .Select(l => new LogViewModel
                {
                    Id = l.Id,
                    UserName = l.User.Name,
                    ActionType = l.Action,
                    Description = l.Details,
                    Timestamp = l.Timestamp,
                    EntityType = l.Source
                })
                .ToListAsync();

            ViewBag.CurrentFilter = actionType;
            return View(logs);
        }
    }
} 