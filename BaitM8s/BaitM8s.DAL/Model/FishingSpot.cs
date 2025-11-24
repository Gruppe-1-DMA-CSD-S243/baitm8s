using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Model
{
    public class FishingSpot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Capacity { get; set; }
        public List<string> FishSpecies { get; set; }
        public bool HandicapFriendly { get; set; }

        public FishingSpot(string name, string address, string zipCode, float longitude, float latitude, int capacity, List<string> fishSpecies, bool handicapFriendly)
        {
            Name = name;
            Address = address;
            ZipCode = zipCode;
            Longitude = longitude;
            Latitude = latitude;
            Capacity = capacity;
            FishSpecies = fishSpecies;
            HandicapFriendly = handicapFriendly;
        }

        public FishingSpot()
        {
        }

        public override string ToString()
        {
            return $"FishingSpot(Id={Id}, Name={Name}";
        }
    }
}
