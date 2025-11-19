using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Model
{
    public class PutAndTakePond : FishingSpot
    {
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int SizeInSquareMeters { get; set; }
        public bool Toilet { get; set; }
        public bool CleanTable { get; set; }
        public bool HandicapFriendly { get; set; }
        public bool FamilyFriendly { get; set; }
        public string LinkToWebsite { get; set; }

        public PutAndTakePond(int id, string fishingSpotNumber, string name, Coordinate location, List<string> fishSpecies, string spotType, bool fishingLicenseRequired, string address, string zipCode, string email, string phoneNumber, int sizeInSquareMeters, bool toilet, bool cleanTable, bool handicapFriendly, bool familyFriendly, string linkToWebsite, int fk_FishingSpotId) : base(id, fishingSpotNumber, name, location, fishSpecies, spotType, fishingLicenseRequired)
        {
            Address = address;
            ZipCode = zipCode;
            Email = email;
            PhoneNumber = phoneNumber;
            SizeInSquareMeters = sizeInSquareMeters;
            Toilet = toilet;
            CleanTable = cleanTable;
            HandicapFriendly = handicapFriendly;
            FamilyFriendly = familyFriendly;
            LinkToWebsite = linkToWebsite;
        }

        public PutAndTakePond()
        {
        }

        public override string ToString() => $"{FishingSpotNumber} - {Name}";
    }
}
