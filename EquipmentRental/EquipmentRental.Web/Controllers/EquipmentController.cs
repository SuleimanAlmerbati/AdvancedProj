using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipmentRental.Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly CourseDBContext _context;
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(CourseDBContext context, ILogger<EquipmentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var equipment = _context.Equipment
                .Include(e => e.Category)
                .ToList();
            return View(equipment);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("Loading Create view with categories");
            ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipment equipment)
        {

            if (string.IsNullOrWhiteSpace(equipment.Name))
            {
                _logger.LogWarning("Name is required");
                ModelState.AddModelError("Name", "Equipment name is required.");
            }

            if (equipment.RentalPrice <= 0)
            {
                _logger.LogWarning("Rental price must be greater than zero");
                ModelState.AddModelError("RentalPrice", "Rental price must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(equipment.AvailabilityStatus))
            {
                _logger.LogWarning("Availability status is required");
                ModelState.AddModelError("AvailabilityStatus", "Availability status is required.");
            }

            if (string.IsNullOrWhiteSpace(equipment.ConditionStatus))
            {
                _logger.LogWarning("Condition status is required");
                ModelState.AddModelError("ConditionStatus", "Condition status is required.");
            }

            if (equipment.CategoryId <= 0)
            {
                _logger.LogWarning("Category is required");
                ModelState.AddModelError("CategoryId", "Category is required.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid");
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
                //return View(equipment);
            }

            try
            {
                _context.Equipment.Add(equipment);
                _context.SaveChanges();
                _logger.LogInformation($"Equipment '{equipment.Name}' created successfully.");
                TempData["SuccessMessage"] = $"Equipment '{equipment.Name}' created successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating equipment");
                ModelState.AddModelError("", "An error occurred while saving the equipment. Please try again.");
                ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Categories, "Id", "Name");
                return View(equipment);
            }
        }

        public IActionResult Edit(int id)
        {
            var equipment = _context.Equipment.Find(id);
            if (equipment == null) return NotFound();

            ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Categories, "Id", "Name");
            return View(equipment);
        }

        [HttpPost]
        public IActionResult Edit(Equipment equipment)
        {
            if (string.IsNullOrWhiteSpace(equipment.Name))
            {
                ModelState.AddModelError("Name", "Equipment name is required.");
            }

            if (equipment.RentalPrice <= 0)
            {
                ModelState.AddModelError("RentalPrice", "Rental price must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(equipment.AvailabilityStatus))
            {
                ModelState.AddModelError("AvailabilityStatus", "Availability status is required.");
            }

            if (string.IsNullOrWhiteSpace(equipment.ConditionStatus))
            {
                ModelState.AddModelError("ConditionStatus", "Condition status is required.");
            }

            if (equipment.CategoryId <= 0)
            {
                ModelState.AddModelError("CategoryId", "Category is required.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Categories, "Id", "Name");
                //return View(equipment);
            }

            var existing = _context.Equipment.Find(equipment.Id);
            if (existing == null) return NotFound();

            existing.Name = equipment.Name;
            existing.Description = equipment.Description;
            existing.RentalPrice = equipment.RentalPrice;
            existing.AvailabilityStatus = equipment.AvailabilityStatus;
            existing.ConditionStatus = equipment.ConditionStatus;
            existing.CategoryId = equipment.CategoryId;

            _context.SaveChanges();
            _logger.LogInformation($"Equipment '{existing.Name}' updated successfully.");
            TempData["SuccessMessage"] = $"Equipment '{existing.Name}' updated successfully.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var equipment = _context.Equipment.Find(id);
            if (equipment == null) return NotFound();

            _context.Equipment.Remove(equipment);
            _context.SaveChanges();

            _logger.LogInformation($"Equipment '{equipment.Name}' deleted successfully.");
            TempData["SuccessMessage"] = $"Equipment '{equipment.Name}' deleted successfully.";
            return RedirectToAction("Index");
        }
    }
} 