using BaitM8s.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Interfaces
{
    public interface IFishingSpotAPIClient
    {
        Task<FishingSpotDTO?> GetFishingSpotAsync(int id);
        Task<IEnumerable<FishingSpotDTO>> GetAllFishingSpotsAsync();
        Task<IEnumerable<FishingSpotDTO>> GetFishingSpotsByPondOwnerAsync(int id);
        Task<bool> DeleteFishingSpotAsync(int id);
        Task<int> CreateFishingSpotAsync(FishingSpotDTO fishingSpot);
        Task<bool> ManageFishingSpotAsync(FishingSpotDTO fishingSpot);
    }
}
