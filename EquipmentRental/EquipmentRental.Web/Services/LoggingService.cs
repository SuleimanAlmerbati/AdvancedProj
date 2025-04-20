using EquipmentLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Web.Services
{
    public class LoggingService
    {
        private readonly CourseDBContext _context;

        public LoggingService(CourseDBContext context)
        {
            _context = context;
        }

        public async Task LogActionAsync(int userId, string action, string source, string details)
        {
            var log = new Log
            {
                UserId = userId,
                Action = action,
                Source = source,
                Details = details,
                Timestamp = DateTime.Now
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task LogRentalRequestAsync(int userId, string equipmentName, string status)
        {
            await LogActionAsync(
                userId,
                "Request",
                "RentalRequest",
                $"Rental request for {equipmentName} - Status: {status}"
            );
        }

        public async Task LogRentalAsync(int userId, string equipmentName, string status)
        {
            await LogActionAsync(
                userId,
                "Rental",
                "RentalTransaction",
                $"Equipment rented: {equipmentName} - Status: {status}"
            );
        }

        public async Task LogReturnAsync(int userId, string equipmentName, string condition)
        {
            await LogActionAsync(
                userId,
                "Return",
                "ReturnRecord",
                $"Equipment returned: {equipmentName} - Condition: {condition}"
            );
        }

        public async Task LogEquipmentActionAsync(int userId, string action, string equipmentName)
        {
            await LogActionAsync(
                userId,
                action,
                "Equipment",
                $"Equipment {action}: {equipmentName}"
            );
        }

        public async Task LogUserActionAsync(int userId, string action, string targetUserName)
        {
            await LogActionAsync(
                userId,
                action,
                "User",
                $"User {action}: {targetUserName}"
            );
        }
    }
} 