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

        public async Task<int> CreateFishingSpotAsync(FishingSpot fishingSpot, int pondOwnerId)
        {
            var request = new RestRequest("FishingSpot", Method.Post);
            request.AddJsonBody(fishingSpot);
            var response = await _restClient.ExecuteAsync<int>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error creating FishingSpot:{response.StatusCode} - {response.Content}");
            }
            return response.Data;
            
        }

        public async Task<bool> DeleteFishingSpotAsync(int id)
        {
            var request = new RestRequest($"FishingSpot/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error deleting FishingSpot with ID {id}: {response.StatusCode} - {response.Content}");
            }
            return true;
        }

        public async Task<IEnumerable<FishingSpot>> GetAllFishingSpotsAsync()
        {
            var request = new RestRequest("FishingSpots", Method.Get);
            var response = await _restClient.ExecuteAsync<IEnumerable<FishingSpot>>(request);
            if (response == null)
            {
                throw new Exception("Response is null");
            }
            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error retrieving FishingSpot: {response.StatusCode} - {response.Content}");
            }
        }

        public async Task<FishingSpot?> GetFishingSpotAsync(int id)
        {
            var request = new RestRequest($"FishingSpots/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync<FishingSpot>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error retrieving FishingSpot with ID {id}: {response.StatusCode} - {response.Content}");
            }
            return response.Data;
        }

        public async Task<IEnumerable<FishingSpot>> GetFishingSpotsByPondOwnerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FishingSpot> RegisterFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FishingSpot> RemoveOwnershipOnFishingSpotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateFishingSpotAsync(int id, FishingSpot fishingSpot)
        {
            var request = new RestRequest($"FishingSpot/{id}", Method.Put);
            request.AddJsonBody(fishingSpot);
            var response = await _restClient.ExecuteAsync<int>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error updating FishingSpot with ID {id}: {response.StatusCode} - {response.Content}");
            }
            return response.Data;
        }
    }
}
