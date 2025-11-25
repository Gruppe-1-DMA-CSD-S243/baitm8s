using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
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

        public async Task<int> CreateFishingSpotAsync(FishingSpot spot)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            using var transaction = connection.BeginTransaction();

            try
            {
                var zipcodeId = await connection.ExecuteScalarAsync<int>(
                @"IF EXISTS (SELECT 1 FROM Zipcode WHERE Zipcode = @ZipCode)
                      SELECT Id FROM Zipcode WHERE Zipcode = @ZipCode
                  ELSE
                  BEGIN
                      INSERT INTO Zipcode (Zipcode) VALUES (@ZipCode);
                      SELECT CAST(SCOPE_IDENTITY() as int);
                  END",
                new { ZipCode = spot.ZipCode },
                transaction);
                var id = await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO FishingSpot (Name, Address, FK_zipcodeId, Longitude, Latitude, StartAvailableHours, EndAvailableHours, Capacity, HandicapFriendly, FK_PondOwnerId)
                  VALUES (@Name, @Address, @ZipcodeId, @Longitude, @Latitude, @StartAvailableHours, @EndAvailableHours, @Capacity, @HandicapFriendly, @FK_PondOwnerId);
                  SELECT CAST(SCOPE_IDENTITY() as int);", 
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
                    var speciesId = await connection.ExecuteScalarAsync<int>(
                        @"IF EXISTS (SELECT 1 FROM FishSpecies WHERE Species = @Species)
                      SELECT Id FROM FishSpecies WHERE Species = @Species
                  ELSE
                  BEGIN
                      INSERT INTO FishSpecies (Species) VALUES (@Species);
                      SELECT CAST(SCOPE_IDENTITY() as int);
                  END",
                        new { Species = species },
                        transaction);

                    await connection.ExecuteAsync(
                        @"INSERT INTO FishSpecies_FishingSpot (FK_FishSpeciesId, FK_FishingSpotId)
                  VALUES (@FishSpeciesId, @FishingSpotId)",
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
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            try
            {
                await connection.ExecuteAsync(
                    "DELETE FROM FishSpecies_FishingSpot WHERE FK_FishingSpotId = @Id",
                    new { Id = id },
                    transaction);

                await connection.ExecuteAsync(
                    "DELETE FROM FishingSpot WHERE Id = @Id",
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
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var spots = (await connection.QueryAsync<FishingSpot>(
                @"select fs.id, fs.name, fs.address, z.zipcode as zipcode,
                 fs.longitude, fs.latitude, fs.startavailablehours, fs.endavailablehours, fs.capacity, fs.handicapfriendly, fs.fk_pondownerid
          from fishingspot fs
          inner join zipcode z on fs.fk_zipcodeid = z.id")).ToList();

            foreach (var spot in spots)
            {
                var species = await connection.QueryAsync<string>(
                    @"select f.species
              from fishspecies f
              inner join fishspecies_fishingspot ffs on f.id = ffs.fk_fishspeciesid
              where ffs.fk_fishingspotid = @id",
                    new { id = spot.Id });

                spot.FishSpecies = species.ToList();
            }

            return spots;

        }

        public async Task<FishingSpot?> GetFishingSpotAsync(int id)
        {
            var query = @"SELECT * FROM FishingSpot WHERE Id = @Id";
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

        //TODO: Skal opdateres.
        public async Task<bool> ManageFishingSpotAsync(FishingSpot fishingSpot)
        {
            var query = @"UPDATE FishingSpot
                      SET Name = @Name,
                          Capacity = @Capacity,
                          StartAvailableHours = @StartAvailableHours,
                          EndAvailableHours = @EndAvailableHours,
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