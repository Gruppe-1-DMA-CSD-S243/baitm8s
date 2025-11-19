using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DAO
{
    public class InMemoryPutAndTakePondDAO : BaseDAO, IPutAndTakePondDAO
    {
        private readonly List<PutAndTakePond> _putAndTakePonds;

        public InMemoryPutAndTakePondDAO(string connectionString) : base(connectionString)
        {
            _putAndTakePonds = new List<PutAndTakePond>
            {
                new PutAndTakePond()
                {
                    Id = 1,
                    FishingSpotNumber = "FS-1",
                    Name = "Name 1",
                    Location = new Coordinate{ Longitude = 10, Latitude = 20 },
                    FishSpecies = new List<string>(),
                    SpotType = "PutAndTake",
                    FishingLicenseRequired = false,
                    Address = "Street 1",
                    ZipCode = "9000",
                    Email = "email@email1.com",
                    PhoneNumber = "11223344",
                    SizeInSquareMeters = 500,
                    Toilet = true,
                    CleanTable = true,
                    HandicapFriendly = false,
                    FamilyFriendly = true,
                    LinkToWebsite = "https://www.google.com"
                },
                new PutAndTakePond()
                {
                    Id = 2,
                    FishingSpotNumber = "FS-2",
                    Name = "Name 2",
                    Location = new Coordinate{ Longitude = 50, Latitude = 80 },
                    FishSpecies = new List<string>(),
                    SpotType = "PutAndTake",
                    FishingLicenseRequired = false,
                    Address = "Street 2",
                    ZipCode = "9000",
                    Email = "email@email2.com",
                    PhoneNumber = "55667788",
                    SizeInSquareMeters = 500,
                    Toilet = true,
                    CleanTable = true,
                    HandicapFriendly = false,
                    FamilyFriendly = true,
                    LinkToWebsite = "https://www.google.com"
                }
            };
        }

        public async Task<int> CreatePutAndTakePondAsync(PutAndTakePond pond)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePutAndTakePondAsync(int pondNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PutAndTakePond>> GetAllPutAndTakePondsAsync()
        {
            return _putAndTakePonds;
        }

        public async Task<PutAndTakePond> GetPutAndTakePondByIdAsync(int pondNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePutAndTakePondAsync(PutAndTakePond pond)
        {
            throw new NotImplementedException();
        }
    }
}
