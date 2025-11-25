using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Model;

namespace BaitM8s.API.Mappings.Interfaces
{
    public interface IFishingSpotMapper
    {
        public FishingSpot ToModel(FishingSpotDTO dto);
    }
}
