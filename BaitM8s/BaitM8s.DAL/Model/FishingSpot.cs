using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Model
{
    public class FishingSpot
    {
        public int FishingSpotNumber { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public string FishSpecies { get; set; }
        public string SpotType { get; set; }
        public bool FishingLicenseRequired { get; set; }

        public FishingSpot(int fishingSpotNumber, string name, string coordinates, string fishSpecies, string spotType, bool fishingLicenseRequired)
        {
            FishingSpotNumber = fishingSpotNumber;
            Name = name;
            Coordinates = coordinates;
            FishSpecies = fishSpecies;
            SpotType = spotType;
            FishingLicenseRequired = fishingLicenseRequired;
        }

        public FishingSpot(string name, string coordinates, string fishSpecies, string spotType, bool fishingLicenseRequired)
        {
            Name = name;
            Coordinates = coordinates;
            FishSpecies = fishSpecies;
            SpotType = spotType;
            FishingLicenseRequired = fishingLicenseRequired;
        }

        public FishingSpot()
        {
        }
    }
}
