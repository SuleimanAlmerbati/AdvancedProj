using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;

namespace EquipmentRental.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly CourseDBContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(CourseDBContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
            //return View("~/Views/Admin/Users/Index.cshtml", users);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("", "Email already exists.");
                return View(user);
            }

            if (!IsStrongPassword(user.PasswordHash))
            {
                ModelState.AddModelError("", "Password must be at least 8 characters, include uppercase, lowercase, number, special character, and no repeating or sequential characters.");
                return View(user);
            }

            user.PasswordHash = HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"User {user.Name} was created successfully.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            var viewModel = new UserEditViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel viewModel)
        {
            _logger.LogInformation($"Edit action called for user ID: {viewModel.Id}");
            
            var existing = _context.Users.FirstOrDefault(u => u.Id == viewModel.Id);
            if (existing == null)
            {
                _logger.LogWarning($"User not found with ID: {viewModel.Id}");
                return NotFound();
            }

            // Validate Name
            if (string.IsNullOrWhiteSpace(viewModel.Name) || !System.Text.RegularExpressions.Regex.IsMatch(viewModel.Name, @"^[a-zA-Z\s]+$"))
            {
                _logger.LogWarning($"Invalid name format for user ID: {viewModel.Id}");
                ModelState.AddModelError("Name", "Name is required and must contain only letters.");
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(viewModel.Email) || !System.Text.RegularExpressions.Regex.IsMatch(viewModel.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                _logger.LogWarning($"Invalid email format for user ID: {viewModel.Id}");
                ModelState.AddModelError("Email", "A valid email is required.");
            }
            else if (_context.Users.Any(u => u.Email == viewModel.Email && u.Id != viewModel.Id))
            {
                _logger.LogWarning($"Email already in use for user ID: {viewModel.Id}");
                ModelState.AddModelError("Email", "Email is already in use by another user.");
            }

            // Handle password update
            if (!string.IsNullOrWhiteSpace(viewModel.PasswordHash))
            {
                // New password provided, validate it
                if (!IsStrongPassword(viewModel.PasswordHash))
                {
                    _logger.LogWarning($"Invalid password strength for user ID: {viewModel.Id}");
                    ModelState.AddModelError("PasswordHash", "Password must be strong and not include sequences or repetitions.");
                }
                else
                {
                    // Check if the new password is different from the current one
                    string hashedNewPassword = HashPassword(viewModel.PasswordHash);
                    if (hashedNewPassword == existing.PasswordHash)
                    {
                        _logger.LogWarning($"New password is the same as current password for user ID: {viewModel.Id}");
                        ModelState.AddModelError("PasswordHash", "New password must be different from the current password.");
                    }
                    else
                    {
                        existing.PasswordHash = hashedNewPassword;
                    }
                }
            }
            // If password is empty, keep the existing password (no need to update)

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Model validation failed for user ID: {viewModel.Id}");
                return View(viewModel);
            }

            // Update core fields
            existing.Name = viewModel.Name;
            existing.Email = viewModel.Email;
            existing.Role = viewModel.Role;

            try
            {
                _context.SaveChanges();
                _logger.LogInformation($"User {existing.Name} was updated successfully");
                TempData["SuccessMessage"] = $"User {existing.Name} was updated successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating user ID: {viewModel.Id}");
                ModelState.AddModelError("", "An error occurred while saving the changes. Please try again.");
                return View(viewModel);
            }
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i])) hasUpper = true;
                else if (char.IsLower(password[i])) hasLower = true;
                else if (char.IsDigit(password[i])) hasDigit = true;
                else if ("!@#$%^&*()-_=+[]{};:'\",.<>?/\\|`~".Contains(password[i])) hasSpecial = true;

                if (i >= 2 && password[i] == password[i - 1] && password[i] == password[i - 2])
                    return false;

                if (i >= 2)
                {
                    int first = password[i - 2];
                    int second = password[i - 1];
                    int third = password[i];

                    if (second == first + 1 && third == second + 1 ||
                        second == first - 1 && third == second - 1)
                        return false;
                }
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }


    }
}
