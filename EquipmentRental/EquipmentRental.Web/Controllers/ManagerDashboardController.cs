using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Web.Controllers
{
    public class ManagerDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
