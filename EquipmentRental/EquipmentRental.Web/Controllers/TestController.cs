using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;
using System.Linq;

namespace EquipmentRental.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly CourseDBContext _context;

        public TestController(CourseDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var equipmentList = _context.Equipment.ToList(); // 👈 Assuming you have an Equipment table
            return View(equipmentList);
        }
    }
}
