using System;

namespace EquipmentRental.Web.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string EntityType { get; set; }

        public string GetActionIcon()
        {
            return ActionType switch
            {
                "Request" => "📝",
                "Rental" => "🔑",
                "Return" => "🔙",
                "Create" => "➕",
                "Update" => "✏️",
                "Delete" => "🗑️",
                _ => "📋"
            };
        }

        public string GetActionColor()
        {
            return ActionType switch
            {
                "Request" => "bg-info",
                "Rental" => "bg-success",
                "Return" => "bg-warning",
                "Create" => "bg-primary",
                "Update" => "bg-secondary",
                "Delete" => "bg-danger",
                _ => "bg-dark"
            };
        }
    }
} 