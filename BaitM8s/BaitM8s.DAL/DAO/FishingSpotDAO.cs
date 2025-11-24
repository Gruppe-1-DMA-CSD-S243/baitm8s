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
            var query = @"SELECT * FROM FishingSpot WHERE Id = @Id";
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

        public async Task<bool> ManageFishingSpotAsync(FishingSpotDTO fishingSpot)
        {
            var query = @"UPDATE FishingSpot
                      SET Name = @Name,
                          Capacity = @Capacity,
                          StartAvailableHours = @StartAvailableHours,
                          EndAvailableHours = @EndAvailableHours
                      WHERE Id = @Id;";

            using (var connection = CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(query,
                            new
                            {
                                Name = fishingSpot.Name,
                                Capacity = fishingSpot.Capacity,
                                Id = fishingSpot.Id,
                                StartAvailableHours = fishingSpot.StartAvailableHours,
                                EndAvailableHours = fishingSpot.EndAvailableHours
                            },
                            transaction);

                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw new Exception($"Error updating fishing spot with id {fishingSpot.Id}. Message was {ex.Message}");
                    }
                }
            }
        }
    }
}