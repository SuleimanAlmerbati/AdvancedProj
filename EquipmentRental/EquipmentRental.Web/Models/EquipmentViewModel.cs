namespace EquipmentRental.Web.Models
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public decimal RentalPrice { get; set; }
        public string Condition { get; set; }
        public string ImageUrl { get; set; }

        public string GetConditionBadgeClass()
        {
            return Condition switch
            {
                "New" => "bg-success",
                "Good" => "bg-primary",
                "Fair" => "bg-warning",
                "Poor" => "bg-danger",
                _ => "bg-secondary"
            };
        }
    }
} 