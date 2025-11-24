using BaitM8s.DAL.DTO;

namespace BaitM8s.MVC.Models
{
    public class FishingSpotAvailabilityViewModel
    {
        public FishingSpotDTO FishingSpot { get; set; }
        public DateTime[] WeekDates { get; set; }
        public int SelectedWeek { get; set; }
        public int SelectedYear { get; set; }
    }
}
