using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interfaces
{
    public interface IFishingSpotDAO
    {
        Task<FishingSpot?> GetFishingSpotAsync(int id);
        Task<IEnumerable<FishingSpot>> GetAllFishingSpotsAsync();
        Task<IEnumerable<FishingSpot>> GetFishingSpotsByPondOwnerAsync(int id);
        Task<FishingSpot> RemoveOwnershipOnFishingSpotAsync(int id);
        Task<bool> DeleteFishingSpotAsync(int id);
        Task<FishingSpot> RegisterFishingSpotAsync(int id);
        Task<int> CreateFishingSpotAsync(FishingSpot fishingSpot);
        Task<int> UpdateFishingSpotAsync(int id, FishingSpot fishingSpot);

    }
}
