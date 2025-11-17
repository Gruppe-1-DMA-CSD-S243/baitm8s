using BaitM8s.APIClient.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    public class BookingAPIClient<T> : IAPIClient<T>
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public BookingAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var request = new RestRequest("bookings", Method.Get);
            var response = await _restClient.ExecuteAsync<IEnumerable<T>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error getting all bookings. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<T?> GetOneAsync(int id)
        {
            var request = new RestRequest("bookings/{id}", Method.Get);
            request.AddUrlSegment("id", id); 

            var response = await _restClient.ExecuteAsync<T>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error getting booking with id {id}. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var request = new RestRequest("Bookings", Method.Delete);
            request.AddParameter("id", id);

            var response = await _restClient.ExecuteAsync<bool>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error deleting booking with id {id}. Message was {response.StatusDescription}");
            }

            return response.Data;
        }
    }
}
