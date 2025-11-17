using BaitM8s.APIClient.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    public class TimeSlotAPIClient<T> : IAPIClient<T>
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public TimeSlotAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var request = new RestRequest("TimeSlots", Method.Get);

            var response = await _restClient.ExecuteAsync<IEnumerable<T>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error getting all TimeSlots. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public Task<T?> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
