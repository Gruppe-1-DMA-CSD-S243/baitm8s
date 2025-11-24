using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    public class FishingSpotAPIClient : IFishingSpotDAO
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public FishingSpotAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
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
            var request = new RestRequest("fishingspots", Method.Get);
            var response = await _restClient.ExecuteAsync<IEnumerable<FishingSpotDTO>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving all bookings. Message was {response.StatusDescription}");
            }

            return response.Data;
        }
        

        public async Task<FishingSpotDTO?> GetFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FishingSpotDTO>> GetFishingSpotsByPondOwnerAsync(int id)
        {
            var request = new RestRequest("fishingspots", Method.Get);
            request.AddUrlSegment("id", id);
            
            var response = await _restClient.ExecuteAsync<IEnumerable<FishingSpotDTO>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving all fishing spots for . Message was {response.StatusDescription}");
            }

            return response.Data;

            //var request = new RestRequest("bookings/{id}", Method.Get);
            //request.AddUrlSegment("id", id);

            //var response = await _restClient.ExecuteAsync<BookingDTO>(request);

            //if (!response.IsSuccessful || response.Data == null)
            //{
            //    throw new Exception($"Error retrieving booking with id {id}. Message was {response.StatusDescription}");
            //}

            //return response.Data;
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
