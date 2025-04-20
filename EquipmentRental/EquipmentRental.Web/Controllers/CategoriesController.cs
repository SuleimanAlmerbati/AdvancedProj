using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;

namespace EquipmentRental.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CourseDBContext _context;

        public CategoriesController(CourseDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Category name is required.");
            }

            if (!ModelState.IsValid)
                return View(category);

            _context.Categories.Add(category);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Category '{category.Name}' created successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Category name is required.");
            }

            if (!ModelState.IsValid)
                return View(category);

            var existing = _context.Categories.Find(category.Id);
            if (existing == null) return NotFound();

            existing.Name = category.Name;
            existing.Description = category.Description;

            _context.SaveChanges();
            TempData["SuccessMessage"] = $"Category '{existing.Name}' updated successfully.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Category '{category.Name}' deleted.";
            return RedirectToAction("Index");
        }
    }
}
