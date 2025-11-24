using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
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

        public async Task<int> CreateFishingSpotAsync(FishingSpot fishingSpot)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FishingSpot>> GetAllFishingSpotsAsync()
        {
            var query = "SELECT * FROM FishingSpot";
            using var connection = CreateConnection();
            return await connection.QueryAsync<FishingSpot>(query);
        }

        public async Task<FishingSpot?> GetFishingSpotAsync(int id)
        {
            var query = @"SELECT * FROM FishingSpot WHERE = @Id";
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<FishingSpot>(query, new { Id = id });
        }

        public async Task<IEnumerable<FishingSpot>> GetFishingSpotsByPondOwnerAsync(int id)
        {
            var query = @"SELECT * FROM FishingSpot WHERE FK_PondOwner = @Id";
            using var connection = CreateConnection();
            return await connection.QueryAsync<FishingSpot>(query, new { Id = id });
        }

        public async Task<FishingSpot> RegisterFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FishingSpot> RemoveOwnershipOnFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
