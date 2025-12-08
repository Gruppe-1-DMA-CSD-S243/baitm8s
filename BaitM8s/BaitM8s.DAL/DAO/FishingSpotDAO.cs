using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DAO
{
    public class FishingSpotDAO : BaseDAO, IFishingSpotDAO
    {
        private readonly string _insertFishingSpotSql = @"
            INSERT INTO FishingSpot 
                (Name, Address, FK_zipcodeId, Longitude, Latitude, 
                 StartAvailableHours, EndAvailableHours, Capacity, HandicapFriendly, FK_PondOwnerId)
            VALUES 
                (@Name, @Address, @ZipcodeId, @Longitude, @Latitude,
                 @StartAvailableHours, @EndAvailableHours, @Capacity, @HandicapFriendly, @FK_PondOwnerId);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
        private readonly string _deleteFishingSpotSql = @"DELETE FROM FishingSpot WHERE Id = @Id;";
        private readonly string _getAllFishingSpotsSql = @"
            SELECT 
            fs.Id, fs.Name, fs.Address, z.Zipcode,
            fs.Longitude, fs.Latitude, fs.StartAvailableHours,
            fs.EndAvailableHours, fs.Capacity, fs.HandicapFriendly,
            fs.FK_PondOwnerId,
            f.Species
            FROM FishingSpot fs
            INNER JOIN Zipcode z ON fs.FK_zipcodeId = z.Id
            LEFT JOIN FishSpecies_FishingSpot ffs ON fs.Id = ffs.FK_FishingSpotId
            LEFT JOIN FishSpecies f ON f.Id = ffs.FK_FishSpeciesId
            ORDER BY fs.Id;";
        private readonly string _getFishingSpotByIdSql = @"SELECT * FROM FishingSpot WHERE Id = @Id;";
        private readonly string _getFishingSpotsByPondOwnerSql = @"SELECT * FROM FishingSpot WHERE FK_PondOwner = @Id;";
        private readonly string _updateFishingSpotSql = @"
            UPDATE FishingSpot
            SET 
                Name = @Name,
                Address = @Address,
                FK_zipcodeId = @ZipcodeId,
                Longitude = @Longitude,
                Latitude = @Latitude,
                StartAvailableHours = @StartAvailableHours,
                EndAvailableHours = @EndAvailableHours,
                Capacity = @Capacity,
                HandicapFriendly = @HandicapFriendly,
                FK_PondOwnerId = @FK_PondOwnerId
            WHERE Id = @Id;";
        private readonly string _deleteFishSpeciesFishingSpotSql = @"DELETE FROM FishSpecies_FishingSpot WHERE FK_FishingSpotId = @Id;";
        private readonly string _insertFishSpeciesFishingSpotSql = @"
            INSERT INTO FishSpecies_FishingSpot (FK_FishSpeciesId, FK_FishingSpotId)
            VALUES (@FishSpeciesId, @FishingSpotId);";
        private readonly string _getOrCreateZipcodeSql = @"
            IF EXISTS (SELECT 1 FROM Zipcode WHERE Zipcode = @ZipCode)
                SELECT Id FROM Zipcode WHERE Zipcode = @ZipCode
            ELSE
            BEGIN
                INSERT INTO Zipcode (Zipcode) VALUES (@ZipCode);
                SELECT CAST(SCOPE_IDENTITY() as int);
            END;";
        private readonly string _getOrCreateFishSpeciesSql = @"
            IF EXISTS (SELECT 1 FROM FishSpecies WHERE Species = @Species)
                SELECT Id FROM FishSpecies WHERE Species = @Species
            ELSE
            BEGIN
                INSERT INTO FishSpecies (Species) VALUES (@Species);
                SELECT CAST(SCOPE_IDENTITY() as int);
            END;";
        
        public FishingSpotDAO(string connectionString) : base(connectionString)
        {
        }

        public async Task<int> CreateFishingSpotAsync(FishingSpot spot)
        {
            using var connection = CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                int zipcodeId = await connection.ExecuteScalarAsync<int>(
                    _getOrCreateZipcodeSql,
                    new { ZipCode = spot.ZipCode },
                    transaction);
                var id = await connection.ExecuteScalarAsync<int>(
                _insertFishingSpotSql,
                new
                {
                    Name = spot.Name,
                    Address = spot.Address,
                    ZipcodeId = zipcodeId,
                    Longitude = spot.Longitude,
                    Latitude = spot.Latitude,
                    StartAvailableHours = spot.StartAvailableHours,
                    EndAvailableHours = spot.EndAvailableHours,
                    Capacity = spot.Capacity,
                    HandicapFriendly = spot.HandicapFriendly,
                    FK_PondOwnerId = spot.FK_PondOwnerId
                },
                transaction);

                foreach (var species in spot.FishSpecies)
                {
                    int speciesId = await connection.ExecuteScalarAsync<int>(
                        _getOrCreateFishSpeciesSql,
                        new { Species = species },
                        transaction);
                    await connection.ExecuteAsync(
                        _insertFishSpeciesFishingSpotSql,
                        new { FishSpeciesId = speciesId, FishingSpotId = id },
                        transaction);
                }

                transaction.Commit();
                return id;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<bool> DeleteFishingSpotAsync(int id)
        {
            using var connection = CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                await connection.ExecuteAsync(
                    _deleteFishSpeciesFishingSpotSql,
                    new { Id = id },
                    transaction);

                await connection.ExecuteAsync(
                    _deleteFishingSpotSql,
                    new { Id = id },
                    transaction);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return true;
        }

        public async Task<IEnumerable<FishingSpot>> GetAllFishingSpotsAsync()
        {
            using var connection = CreateConnection();
            var lookup = new Dictionary<int, FishingSpot>();
            await connection.QueryAsync<FishingSpot, string, FishingSpot>(
                _getAllFishingSpotsSql,
                (spot, species) =>
                {
                    if (!lookup.TryGetValue(spot.Id, out var existingSpot))
                    {
                        existingSpot = spot;
                        existingSpot.FishSpecies = new List<string>();
                        lookup.Add(existingSpot.Id, existingSpot);
                    }
                    if (species != null && !existingSpot.FishSpecies.Contains(species))
                    {
                        existingSpot.FishSpecies.Add(species);
                    }
                    return existingSpot;
                },
                splitOn: "species");
            return lookup.Values;

        }

        public async Task<FishingSpot?> GetFishingSpotAsync(int id)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<FishingSpot>(_getFishingSpotByIdSql, new { Id = id });
        }

        public async Task<IEnumerable<FishingSpot>> GetFishingSpotsByPondOwnerAsync(int id)
        {
            var query = @"SELECT * FROM FishingSpot WHERE FK_PondOwnerId = @Id";
            using var connection = CreateConnection();
            return await connection.QueryAsync<FishingSpot>(query, new { Id = id });
        }

        //TODO: Skal opdateres.
        public async Task<bool> ManageFishingSpotAsync(FishingSpot fishingSpot)
        {
            var query = @"UPDATE FishingSpot
                      SET Name = @Name,
                          Capacity = @Capacity,
                          StartAvailableHours = @StartAvailableHours,
                          EndAvailableHours = @EndAvailableHours
                      WHERE Id = @Id;";

            using var connection = new SqlConnection(_connectionString);
            
                await connection.OpenAsync();

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

        
        public async Task<bool> UpdateFishingSpotAsync(FishingSpot spot)
        {
            using var connection = CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var zipcodeId = await connection.ExecuteScalarAsync<int>(
                    _getOrCreateZipcodeSql,
                    new { ZipCode = spot.ZipCode },
                    transaction);

                int rows = await connection.ExecuteAsync(
                    _updateFishingSpotSql,
                    new
                    {
                        spot.Name,
                        spot.Address,
                        ZipcodeId = zipcodeId,
                        spot.Longitude,
                        spot.Latitude,
                        spot.Capacity,
                        spot.HandicapFriendly,
                        spot.FK_PondOwnerId,
                        spot.Id,
                        spot.StartAvailableHours,
                        spot.EndAvailableHours

                    },
                    transaction);

                if (rows == 0)
                {
                    transaction.Rollback();
                    return false;
                }


                await connection.ExecuteAsync(
                    _deleteFishSpeciesFishingSpotSql,
                    new { spot.Id },
                    transaction);


                foreach (var species in spot.FishSpecies)
                {
                    await connection.ExecuteAsync(
                        _insertFishSpeciesFishingSpotSql,
                        new { Species = species },
                        transaction);
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Transaction was rolled back");
            }
        }
    }
}