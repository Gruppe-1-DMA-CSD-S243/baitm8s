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
        public string FishingSpotNumber { get; set; }
        public string Name { get; set; }
        public Coordinate Location { get; set; }
        public List<string> FishSpecies { get; set; }
        public string SpotType { get; set; }
        public bool FishingLicenseRequired { get; set; }

        public FishingSpot(int id, string fishingSpotNumber, string name, Coordinate location, List<string> fishSpecies, string spotType, bool fishingLicenseRequired)
        {
            Id = id;
            FishingSpotNumber = fishingSpotNumber;
            Name = name;
            Location = location;
            FishSpecies = fishSpecies;
            SpotType = spotType;
            FishingLicenseRequired = fishingLicenseRequired;
        }

        public FishingSpot(int id, string name, Coordinate location, List<string> fishSpecies, string spotType, bool fishingLicenseRequired)
        {
            Name = name;
            Location = location;
            FishSpecies = fishSpecies;
            SpotType = spotType;
            FishingLicenseRequired = fishingLicenseRequired;
        }

        public FishingSpot()
        {
        }
    }
}
