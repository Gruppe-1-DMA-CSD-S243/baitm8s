using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    public class FishingSpotAPIClient : IFishingSpotAPIClient
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
            var request = new RestRequest("FishingSpots", Method.Post);
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
            var request = new RestRequest($"FishingSpots/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error deleting FishingSpot with ID {id}: {response.StatusCode} - {response.Content}");
            }
            return true;
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
            var request = new RestRequest("fishingspots/by-id/{id}", Method.Get);
            request.AddUrlSegment("id", id);

            var response = await _restClient.ExecuteAsync<FishingSpotDTO>(request);
            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving fishing spot. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<IEnumerable<FishingSpotDTO>> GetFishingSpotsByPondOwnerAsync(int id)
        {
            var request = new RestRequest("fishingspots/by-owner/{id}", Method.Get);
            request.AddUrlSegment("id", id);

            var response = await _restClient.ExecuteAsync<IEnumerable<FishingSpotDTO>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving all fishing spots for id {id}. Message was {response.StatusDescription}");
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

        public async Task<bool> ManageFishingSpotAsync(FishingSpotDTO fishingSpot)
        {
            int id = fishingSpot.Id;
            var request = new RestRequest("fishingspots/{id}", Method.Put);
            request.AddUrlSegment("id", id);
            request.AddJsonBody(fishingSpot);

            var response = await _restClient.ExecuteAsync<bool>(request);
            if (response == null)
            {
                throw new Exception("No response from server");
            }
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error updating fishing spot with id {id}. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<bool> UpdateFishingSpotAsync(FishingSpotDTO fishingSpot)
        {
            int id = fishingSpot.Id;
            var request = new RestRequest("fishingspots/{id}", Method.Put);
            request.AddUrlSegment("id", id);
            request.AddJsonBody(fishingSpot);
            var response = await _restClient.ExecuteAsync<bool>(request);
            if (response == null)
            {
                throw new Exception("No response from server");
            }
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error updating fishing spot with id {id}. Message was {response.StatusDescription}");
            }
            return response.Data;
        }
    }
}