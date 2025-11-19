using BaitM8s.APIClient.Interfaces;
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
    public class PutAndTakePondApiClient : IPutAndTakePondDAO
    {
        private readonly RestClient _restClient;
        private readonly string _apiBaseUri;
        public PutAndTakePondApiClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }
        public async Task<int> CreatePutAndTakePondAsync(PutAndTakePond pond)
        {
            var request = new RestRequest("PutAndTakePonds", Method.Post);
            request.AddJsonBody(pond);
            var response = await _restClient.ExecuteAsync<int>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error creating PutAndTakePond: {response.StatusCode} - {response.Content}");
            }
            return response.Data;
        }

        public async Task<bool> DeletePutAndTakePondAsync(int pondNumber)
        {
            var request = new RestRequest($"PutAndTakePonds/{pondNumber}", Method.Delete);
            var response = await _restClient.ExecuteAsync<bool>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error deleting PutAndTakePond with ID {pondNumber}: {response.StatusCode} - {response.Content}");
            }
            return response.Data;
        }

        
        public async Task<IEnumerable<PutAndTakePond>> GetAllPutAndTakePondsAsync()
        {
            var request = new RestRequest("PutAndTakePonds", Method.Get);
            var response = await _restClient.ExecuteAsync<IEnumerable<PutAndTakePond>>(request);
            if(response==null)
            {
                throw new Exception("Response is null");
            }
            if (response.Data == null)
            {
                throw new Exception("Response data is null");
            }
            if(response.IsSuccessStatusCode)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error retrieving PutAndTakePonds: {response.StatusCode} - {response.Content}");
            }

        }

        public async Task<PutAndTakePond> GetPutAndTakePondByIdAsync(int pondNumber)
        {
            var request = new RestRequest($"PutAndTakePonds/{pondNumber}", Method.Get);
            var response = await _restClient.ExecuteAsync<PutAndTakePond>(request);
            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving PutAndTakePond with ID {pondNumber}: {response.StatusCode} - {response.Content}");
            }
            return response.Data;
        }

        public async Task<bool> UpdatePutAndTakePondAsync(PutAndTakePond pond)
        {
            var request = new RestRequest($"PutAndTakePonds/{pond.FishingSpotNumber}", Method.Put);
            request.AddJsonBody(pond);
            var response = await _restClient.ExecuteAsync<bool>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error updating PutAndTakePond with ID {pond.FishingSpotNumber}: {response.StatusCode} - {response.Content}");
            }
            return response.Data;
        }
    }
}
