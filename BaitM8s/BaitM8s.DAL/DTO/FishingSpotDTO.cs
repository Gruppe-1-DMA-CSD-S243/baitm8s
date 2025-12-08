using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DTO
{
    public class FishingSpotDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Capacity { get; set; }
        public List<string>? FishSpecies { get; set; }
        public bool HandicapFriendly { get; set; }
        //TODO: Add IsAwaitingApproval coloumn to the FishingSpot table!
        public bool IsAwaitingApproval { get; set; }
        public int StartAvailableHours { get; set; }
        public int EndAvailableHours { get; set; }
        public int FK_PondOwnerId { get; set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name}";
        }
    }
}
