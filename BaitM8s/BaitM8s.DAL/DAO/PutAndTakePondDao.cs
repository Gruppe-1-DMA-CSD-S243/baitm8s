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
    public class PutAndTakePondDao : IPutAndTakePondDao
    {
        private readonly string _deleteSql = @"DELETE FROM PutAndTakePond WHERE PutAndTakePondId = @PutAndTakePondId";
        private readonly string _createPutAndTakePondSql = @"
                INSERT INTO PutAndTakePond 
                    (FishingSpotNumber, Address, ZipCode, Email, PhoneNumber, SizeInSquareMeters,
                    Toilet, CleanTable, HandicapFriendly, FamilyFriendly, LinkToWebsite)
                VALUES 
                    (@FishingSpotNumber, @Address, @ZipCode, @Email, @PhoneNumber, @SizeInSquareMeters,
                    @Toilet, @CleanTable, @HandicapFriendly, @FamilyFriendly, @LinkToWebsite);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
        private readonly string _createFishingSpotSql = @"
                INSERT INTO FishingSpot (Name, Coordinates, FishSpecies, SpotType, FishingLicenseRequired)
                VALUES (@Name, @Coordinates, @FishSpecies, @SpotType, @FishingLicenseRequired);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
        private readonly string _updateFishingSpotSql = @"
                UPDATE FishingSpot
                SET 
                    Name = @Name,
                    Coordinates = @Coordinates,
                    FishSpecies = @FishSpecies,
                    SpotType = @SpotType,
                    FishingLicenseRequired = @FishingLicenseRequired
                WHERE FishingSpotNumber = @FishingSpotNumber;";
        private readonly string _updatePutAndTakePondSql = @"
                UPDATE PutAndTakePond
                SET
                    Address = @Address,
                    ZipCode = @ZipCode,
                    Email = @Email,
                    PhoneNumber = @PhoneNumber,
                    SizeInSquareMeters = @SizeInSquareMeters,
                    Toilet = @Toilet,
                    CleanTable = @CleanTable,
                    HandicapFriendly = @HandicapFriendly,
                    FamilyFriendly = @FamilyFriendly,
                    LinkToWebsite = @LinkToWebsite
                WHERE PutAndTakePondId = @PutAndTakePondId;";
        private readonly string _getAllSql = "SELECT * FROM PutAndTakePond";
        private readonly string _getPutAndTakePondByIdSql = "SELECT * FROM PutAndTakePond WHERE PutAndTakePondId = @PutAndTakePondId";


        private readonly string _connectionString;
        public PutAndTakePondDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreatePutAndTakePondAsync(PutAndTakePond pond)
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                await connection.OpenAsync();

                // 1. Opret FishingSpot og hent ID
                int fishingSpotId;
                using (var command = new SqlCommand(_createFishingSpotSql, connection))
                {
                    command.Parameters.AddWithValue("@Name", pond.Name);
                    command.Parameters.AddWithValue("@Coordinates", pond.Coordinates);
                    command.Parameters.AddWithValue("@FishSpecies", pond.FishSpecies);
                    command.Parameters.AddWithValue("@SpotType", pond.SpotType);
                    command.Parameters.AddWithValue("@FishingLicenseRequired", pond.FishingLicenseRequired);

                    var result = await command.ExecuteScalarAsync();
                    if (result == null || result == DBNull.Value)
                        throw new Exception("Failed to insert FishingSpot.");

                    fishingSpotId = Convert.ToInt32(result);
                }

                // 2. Opret PutAndTakePond og hent ID
                int putAndTakePondId;
                using (var pondCommand = new SqlCommand(_createPutAndTakePondSql, connection))
                {
                    pondCommand.Parameters.AddWithValue("@FishingSpotNumber", fishingSpotId);
                    pondCommand.Parameters.AddWithValue("@Address", pond.Address);
                    pondCommand.Parameters.AddWithValue("@ZipCode", pond.ZipCode);
                    pondCommand.Parameters.AddWithValue("@Email", pond.Email);
                    pondCommand.Parameters.AddWithValue("@PhoneNumber", pond.PhoneNumber);
                    pondCommand.Parameters.AddWithValue("@SizeInSquareMeters", pond.SizeInSquareMeters);
                    pondCommand.Parameters.AddWithValue("@Toilet", pond.Toilet);
                    pondCommand.Parameters.AddWithValue("@CleanTable", pond.CleanTable);
                    pondCommand.Parameters.AddWithValue("@HandicapFriendly", pond.HandicapFriendly);
                    pondCommand.Parameters.AddWithValue("@FamilyFriendly", pond.FamilyFriendly);
                    pondCommand.Parameters.AddWithValue("@LinkToWebsite", pond.LinkToWebsite ?? (object)DBNull.Value);

                    var pondResult = await pondCommand.ExecuteScalarAsync();
                    if (pondResult == null || pondResult == DBNull.Value)
                        throw new Exception("Failed to insert PutAndTakePond.");

                    putAndTakePondId = Convert.ToInt32(pondResult);
                }

                return putAndTakePondId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating PutAndTakePond", ex);
            }
        }


        public async Task DeletePutAndTakePondAsync(int pondNumber)
        {
            using var connection = new SqlConnection(_connectionString);
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(_deleteSql, connection);
                command.Parameters.AddWithValue("@PutAndTakePondId", pondNumber);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting PutAndTakePond", ex);
            }
        }

        
        public async Task<IEnumerable<PutAndTakePond>> GetAllPutAndTakePondsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var list = new List<PutAndTakePond>();

            var sql = @"
        SELECT p.FishingSpotNumber, f.Name, f.Coordinates, f.FishSpecies, f.SpotType, f.FishingLicenseRequired,
               p.Address, p.ZipCode, p.Email, p.PhoneNumber, p.SizeInSquareMeters,
               p.Toilet, p.CleanTable, p.HandicapFriendly, p.FamilyFriendly, p.LinkToWebsite
        FROM PutAndTakePond p
        INNER JOIN FishingSpot f ON p.FishingSpotNumber = f.FishingSpotNumber
    ";

            await connection.OpenAsync();
            using var command = new SqlCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var pond = new PutAndTakePond
                {
                    FishingSpotNumber = reader.GetInt32(reader.GetOrdinal("FishingSpotNumber")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Coordinates = reader.GetString(reader.GetOrdinal("Coordinates")),
                    FishSpecies = reader.GetString(reader.GetOrdinal("FishSpecies")),
                    SpotType = reader.GetString(reader.GetOrdinal("SpotType")),
                    FishingLicenseRequired = reader.GetBoolean(reader.GetOrdinal("FishingLicenseRequired")),

                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    ZipCode = reader.GetString(reader.GetOrdinal("ZipCode")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                    SizeInSquareMeters = reader.GetInt32(reader.GetOrdinal("SizeInSquareMeters")),
                    Toilet = reader.GetBoolean(reader.GetOrdinal("Toilet")),
                    CleanTable = reader.GetBoolean(reader.GetOrdinal("CleanTable")),
                    HandicapFriendly = reader.GetBoolean(reader.GetOrdinal("HandicapFriendly")),
                    FamilyFriendly = reader.GetBoolean(reader.GetOrdinal("FamilyFriendly")),
                    LinkToWebsite = reader.IsDBNull(reader.GetOrdinal("LinkToWebsite"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("LinkToWebsite"))
                };

                list.Add(pond);
            }

            return list;
        }

        public async Task<PutAndTakePond> GetPutAndTakePondByIdAsync(int pondNumber)
        {
            using var connection = new SqlConnection(_connectionString);
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(_getPutAndTakePondByIdSql, connection);
                command.Parameters.AddWithValue("@PutAndTakePondId", pondNumber);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return SingleDataReaderToPutAndTakePonds(reader);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving PutAndTakePond by ID", ex);
            }
        }


        public async Task UpdatePutAndTakePondAsync(PutAndTakePond pond)
        {
            using var connection = new SqlConnection(_connectionString);
            try
            {
                await connection.OpenAsync();
                using var transaction = connection.BeginTransaction();
                try
                {
                    // Opdater FishingSpot
                    using (var fishingSpotCommand = new SqlCommand(_updateFishingSpotSql, connection, transaction))
                    {
                        fishingSpotCommand.Parameters.AddWithValue("@Name", pond.Name);
                        fishingSpotCommand.Parameters.AddWithValue("@Coordinates", pond.Coordinates);
                        fishingSpotCommand.Parameters.AddWithValue("@FishSpecies", pond.FishSpecies);
                        fishingSpotCommand.Parameters.AddWithValue("@SpotType", pond.SpotType);
                        fishingSpotCommand.Parameters.AddWithValue("@FishingLicenseRequired", pond.FishingLicenseRequired);
                        fishingSpotCommand.Parameters.AddWithValue("@FishingSpotNumber", pond.FishingSpotNumber);
                        await fishingSpotCommand.ExecuteNonQueryAsync();
                    }
                    // Opdater PutAndTakePond
                    using (var pondCommand = new SqlCommand(_updatePutAndTakePondSql, connection, transaction))
                    {
                        pondCommand.Parameters.AddWithValue("@Address", pond.Address);
                        pondCommand.Parameters.AddWithValue("@ZipCode", pond.ZipCode);
                        pondCommand.Parameters.AddWithValue("@Email", pond.Email);
                        pondCommand.Parameters.AddWithValue("@PhoneNumber", pond.PhoneNumber);
                        pondCommand.Parameters.AddWithValue("@SizeInSquareMeters", pond.SizeInSquareMeters);
                        pondCommand.Parameters.AddWithValue("@Toilet", pond.Toilet);
                        pondCommand.Parameters.AddWithValue("@CleanTable", pond.CleanTable);
                        pondCommand.Parameters.AddWithValue("@HandicapFriendly", pond.HandicapFriendly);
                        pondCommand.Parameters.AddWithValue("@FamilyFriendly", pond.FamilyFriendly);
                        pondCommand.Parameters.AddWithValue("@LinkToWebsite", pond.LinkToWebsite ?? (object)DBNull.Value);
                        pondCommand.Parameters.AddWithValue("@PutAndTakePondId", pond.FishingSpotNumber);
                        await pondCommand.ExecuteNonQueryAsync();
                    }
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating PutAndTakePond", ex);
            }
        }





        private IEnumerable<PutAndTakePond> DataReaderToPutAndTakePonds(SqlDataReader reader)
        {
            List<PutAndTakePond> ponds = new List<PutAndTakePond>();
            while (reader.Read())
            {
                ponds.Add(SingleDataReaderToPutAndTakePonds(reader));
            }
            return ponds;
        }

        

        private PutAndTakePond SingleDataReaderToPutAndTakePonds(SqlDataReader reader)
        {
            PutAndTakePond pond = new PutAndTakePond();
            pond.FishingSpotNumber = (int)reader["FishingSpotNumber"];
            pond.Name = (string)reader["Name"];
            pond.Coordinates = (string)reader["Coordinates"];
            pond.FishSpecies = (string)reader["FishSpecies"];
            pond.SpotType = (string)reader["SpotType"];
            pond.FishingLicenseRequired = (bool)reader["FishingLicenseRequired"];
            pond.Address = (string)reader["Address"];
            pond.ZipCode = (string)reader["ZipCode"];
            pond.Email = (string)reader["Email"];
            pond.PhoneNumber = (string)reader["PhoneNumber"];
            pond.SizeInSquareMeters = (int)reader["SizeInSquareMeters"];
            pond.Toilet = (bool)reader["Toilet"];
            pond.CleanTable = (bool)reader["CleanTable"];
            pond.HandicapFriendly = (bool)reader["HandicapFriendly"];
            pond.FamilyFriendly = (bool)reader["FamilyFriendly"];
            pond.LinkToWebsite = (string)reader["LinkToWebsite"];

            return pond;
        }

    }
}
