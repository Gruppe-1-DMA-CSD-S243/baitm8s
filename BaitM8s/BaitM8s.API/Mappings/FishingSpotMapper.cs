using BaitM8s.API.Mappings.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Model;

namespace BaitM8s.API.Mappings
{
    public class FishingSpotMapper : IFishingSpotMapper
    {
        public FishingSpot ToModel(FishingSpotDTO dto)
        {
            FishingSpot fishingSpot = new FishingSpot
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                ZipCode = dto.ZipCode,
                Longitude = dto.Longitude,
                Latitude = dto.Latitude,
                Capacity = dto.Capacity,
                FishSpecies = dto.FishSpecies,
                HandicapFriendly = dto.HandicapFriendly,
                IsAwaitingApproval = dto.IsAwaitingApproval,
                StartAvailableHours = dto.StartAvailableHours,
                EndAvailableHours = dto.EndAvailableHours
            };

            return fishingSpot;
        }
    }
}
