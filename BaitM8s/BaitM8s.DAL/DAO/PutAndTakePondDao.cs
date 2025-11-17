using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
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
        private readonly string _deleteSql = "DELETE FROM PutAndTakePond WHERE id = @PutAndTakePondId";
        private readonly string _createPutAndTakePondSql = "INSERT INTO PutAndTakePond (Name, Coordinates, FishSpecies, SpotType, FishingLicenseRequired, Address, ZipCode, Email, PhoneNumber, SizeInSquareMeters, Toilet, CleanTable, HandicapFriendly, FamilyFriendly, LinkToWebsite) VALUES (@Name, @Coordinates, @FishSpecies, @SpotType, @FishingLicenseRequired, @Address, @ZipCode, @Email, @PhoneNumber, @SizeInSquareMeters, @Toilet, @CleanTable, @HandicapFriendly, @FamilyFriendly, @LinkToWebsite); SELECT CAST(SCOPE_IDENTITY() as int)";
        private readonly string _createFishingSpotSql = "INSERT INTO FishingSpots (Name, Coordinates, FishSpecies, SpotType, FishingLicenseRequired) VALUES (@Name, @Coordinates, @FishSpecies, @SpotType, @FishingLicenseRequired); SELECT CAST(SCOPE_IDENTITY() as int)";
        private readonly string _updateSql = "UPDATE PutAndTakePond SET Name = @Name, Coordinates = @Coordinates, FishSpecies = @FishSpecies, SpotType = @SpotType, FishingLicenseRequired = @FishingLicenseRequired, Address = @Address, ZipCode = @ZipCode, Email = @Email, PhoneNumber = @PhoneNumber, SizeInSquareMeters = @SizeInSquareMeters, Toilet = @Toilet, CleanTable = @CleanTable, HandicapFriendly = @HandicapFriendly, FamilyFriendly = @FamilyFriendly, LinkToWebsite = @LinkToWebsite WHERE id = @PutAndTakePondId";
        private readonly string _getAllSql = "SELECT * FROM PutAndTakePond";
        private readonly string _getPutAndTakePondByIdSql = "SELECT * FROM PutAndTakePond WHERE id = @PutAndTakePondId";


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
                SqlCommand command = new SqlCommand(_createFishingSpotSql, connection);
                command.Parameters.AddWithValue("@Name", pond.Name);
                command.Parameters.AddWithValue("@Coordinates", pond.Coordinates);
                command.Parameters.AddWithValue("@FishSpecies", pond.FishSpecies);
                command.Parameters.AddWithValue("@SpotType", pond.SpotType);
                command.Parameters.AddWithValue("@FishingLicenseRequired", pond.FishingLicenseRequired);
                int fishingSpotId = (int)await command.ExecuteScalarAsync();
                SqlCommand pondCommand = new SqlCommand(_createPutAndTakePondSql, connection);
                pondCommand.Parameters.AddWithValue("@Name", pond.Name);
                pondCommand.Parameters.AddWithValue("@Coordinates", pond.Coordinates);
                pondCommand.Parameters.AddWithValue("@FishSpecies", pond.FishSpecies);
                pondCommand.Parameters.AddWithValue("@SpotType", pond.SpotType);
                pondCommand.Parameters.AddWithValue("@FishingLicenseRequired", pond.FishingLicenseRequired);
                pondCommand.Parameters.AddWithValue("@Address", pond.Address);
                pondCommand.Parameters.AddWithValue("@ZipCode", pond.ZipCode);
                pondCommand.Parameters.AddWithValue("@Email", pond.Email);
                pondCommand.Parameters.AddWithValue("@PhoneNumber", pond.PhoneNumber);
                pondCommand.Parameters.AddWithValue("@SizeInSquareMeters", pond.SizeInSquareMeters);
                pondCommand.Parameters.AddWithValue("@Toilet", pond.Toilet);
                pondCommand.Parameters.AddWithValue("@CleanTable", pond.CleanTable);
                pondCommand.Parameters.AddWithValue("@HandicapFriendly", pond.HandicapFriendly);
                pondCommand.Parameters.AddWithValue("@FamilyFriendly", pond.FamilyFriendly);
                pondCommand.Parameters.AddWithValue("@LinkToWebsite", pond.LinkToWebsite);
                int putAndTakePondId = (int)await pondCommand.ExecuteScalarAsync();
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
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(_getAllSql, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                return DataReaderToPutAndTakePonds(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving PutAndTakePonds", ex);
            }
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
                SqlCommand command = new SqlCommand(_updateSql, connection);
                command.Parameters.AddWithValue("@Name", pond.Name);
                command.Parameters.AddWithValue("@Coordinates", pond.Coordinates);
                command.Parameters.AddWithValue("@FishSpecies", pond.FishSpecies);
                command.Parameters.AddWithValue("@SpotType", pond.SpotType);
                command.Parameters.AddWithValue("@FishingLicenseRequired", pond.FishingLicenseRequired);
                command.Parameters.AddWithValue("@Address", pond.Address);
                command.Parameters.AddWithValue("@ZipCode", pond.ZipCode);
                command.Parameters.AddWithValue("@Email", pond.Email);
                command.Parameters.AddWithValue("@PhoneNumber", pond.PhoneNumber);
                command.Parameters.AddWithValue("@SizeInSquareMeters", pond.SizeInSquareMeters);
                command.Parameters.AddWithValue("@Toilet", pond.Toilet);
                command.Parameters.AddWithValue("@CleanTable", pond.CleanTable);
                command.Parameters.AddWithValue("@HandicapFriendly", pond.HandicapFriendly);
                command.Parameters.AddWithValue("@FamilyFriendly", pond.FamilyFriendly);
                command.Parameters.AddWithValue("@LinkToWebsite", pond.LinkToWebsite);
                command.Parameters.AddWithValue("@PutAndTakePondId", pond.FishingSpotNumber);
                await command.ExecuteNonQueryAsync();
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
            pond.FishingSpotNumber = reader.GetInt32(reader.GetOrdinal("FishingSpotNumber"));
            pond.Name = reader.GetString(reader.GetOrdinal("Name"));
            pond.Coordinates = reader.GetString(reader.GetOrdinal("Coordinates"));
            pond.FishSpecies = reader.GetString(reader.GetOrdinal("FishSpecies"));
            pond.SpotType = reader.GetString(reader.GetOrdinal("SpotType"));
            pond.FishingLicenseRequired = reader.GetBoolean(reader.GetOrdinal("FishingLicenseRequired"));
            pond.Address = reader.GetString(reader.GetOrdinal("Address"));
            pond.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
            pond.Email = reader.GetString(reader.GetOrdinal("Email"));
            pond.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            pond.SizeInSquareMeters = reader.GetInt32(reader.GetOrdinal("SizeInSquareMeters"));
            pond.Toilet = reader.GetBoolean(reader.GetOrdinal("Toilet"));
            pond.CleanTable = reader.GetBoolean(reader.GetOrdinal("CleanTable"));
            pond.HandicapFriendly = reader.GetBoolean(reader.GetOrdinal("HandicapFriendly"));
            pond.FamilyFriendly = reader.GetBoolean(reader.GetOrdinal("FamilyFriendly"));
            pond.LinkToWebsite = reader.GetString(reader.GetOrdinal("LinkToWebsite"));
            return pond;
        }
    }
}
