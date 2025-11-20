using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public int WeekNumber { get; set; }
        public int FK_AnglerId { get; set; }
        public int FK_FishingSpotId { get; set; }
    }
}
