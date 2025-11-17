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
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
        public int FK_FishingSpotId { get; }

        public PutAndTakePond(int fishingSpotNumber, string name, string coordinates, string fishSpecies, string spotType, bool fishingLicenseRequired, string address, string zipCode, string email, string phoneNumber, int sizeInSquareMeters, bool toilet, bool cleanTable, bool handicapFriendly, bool familyFriendly, string linkToWebsite, IEnumerable<TimeSlot> timeSlots, int fk_FishingSpotId) : base(fishingSpotNumber, name, coordinates, fishSpecies, spotType, fishingLicenseRequired)
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
            TimeSlots = timeSlots;
            FK_FishingSpotId = fk_FishingSpotId;
        }

        public PutAndTakePond()
        {
        }
    }
}
