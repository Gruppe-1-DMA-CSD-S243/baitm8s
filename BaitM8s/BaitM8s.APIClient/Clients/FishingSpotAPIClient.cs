using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    public class FishingSpotAPIClient : IFishingSpotDAO
    {
        public async Task<int> CreateFishingSpotAsync(FishingSpot fishingSpot, int pondOwnerId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FishingSpot>> GetAllFishingSpotsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FishingSpot?> GetFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FishingSpot>> GetFishingSpotsByPondOwnerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FishingSpot> RegisterFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FishingSpot> RemoveOwnershipOnFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFishingSpotAsync(int id, FishingSpot fishingSpot)
        {
            throw new NotImplementedException();
        }
    }
}
