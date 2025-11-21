using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DAO
{
    public class FishingSpotDAO : BaseDAO, IFishingSpotDAO
    {
        public FishingSpotDAO(string connectionString) : base(connectionString)
        {
        }

        public async Task<int> CreateFishingSpotAsync(FishingSpotDTO fishingSpot)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FishingSpotDTO>> GetAllFishingSpotsAsync()
        {
            var query = "SELECT * FROM FishingSpot";
            using var connection = CreateConnection();
            return await connection.QueryAsync<FishingSpotDTO>(query);
        }

        public async Task<FishingSpotDTO?> GetFishingSpotAsync(int id)
        {
            var query = @"SELECT * FROM FishingSpot WHERE = @Id";
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<FishingSpotDTO>(query, new { Id = id });
        }

        public async Task<IEnumerable<FishingSpotDTO>> GetFishingSpotsByPondOwnerAsync(int id)
        {
            var query = @"SELECT * FROM FishingSpot WHERE FK_PondOwner = @Id";
            using var connection = CreateConnection();
            return await connection.QueryAsync<FishingSpotDTO>(query, new { Id = id });
        }

        public async Task<FishingSpotDTO> RegisterFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FishingSpotDTO> RemoveOwnershipOnFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
