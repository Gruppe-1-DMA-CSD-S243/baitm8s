using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Model
{
    public class PutAndTakePond
    {
        public int PondNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        public int sizeInSquareMeters { get; set; }
        public bool Toilet { get; set; }
        public bool CleanTable { get; set; }
        public bool HandiCapFriendly { get; set; }
        public bool FamilyFriendly { get; set; }
        public string LinkToWebsite { get; set; }
    }
}
