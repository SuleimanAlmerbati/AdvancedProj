using Microsoft.AspNetCore.Mvc;
using EquipmentLibrary;
using EquipmentLibrary.Model;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace EquipmentRental.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly CourseDBContext _context;
        public AccountController(CourseDBContext context)
        {
            _context = context;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Email and password are required.";
                return View();
            }

            string hashedInput = HashPassword(password);

            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.PasswordHash == hashedInput);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.Name);

            return RedirectToAction("Index", "Home");

        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }




        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
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

            return RedirectToAction("Login");
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

                // Repeating characters
                if (i >= 2 && password[i] == password[i - 1] && password[i] == password[i - 2])
                    return false;

                // Ascending or descending sequences
                if (i >= 2)
                {
                    int first = password[i - 2];
                    int second = password[i - 1];
                    int third = password[i];

                    if ((second == first + 1 && third == second + 1) || // e.g., 123 or abc
                        (second == first - 1 && third == second - 1))   // e.g., 321 or cba
                        return false;
                }
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        private string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return string.Empty;

            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }



    }
}
