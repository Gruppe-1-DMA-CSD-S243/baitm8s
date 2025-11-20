using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    public class BookingAPIClient : IBookingAPIClient
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public BookingAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }

        public async Task<IEnumerable<BookingDTO>> GetAllAsync()
        {
            var request = new RestRequest("bookings", Method.Get);
            var response = await _restClient.ExecuteAsync<IEnumerable<BookingDTO>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving all bookings. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<BookingDTO?> GetOneAsync(int id)
        {
            var request = new RestRequest("bookings/{id}", Method.Get);
            request.AddUrlSegment("id", id); 

            var response = await _restClient.ExecuteAsync<BookingDTO>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving booking with id {id}. Message was {response.StatusDescription}");
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

        public async Task<int> CreateAsync(BookingDTO booking)
        {
            var request = new RestRequest("bookings", Method.Post);
            request.AddJsonBody<BookingDTO>(booking);

            var response = await _restClient.ExecuteAsync<int>(request);

            if (response == null)
            {
                throw new Exception("No reponse from server");
            }

            if (!response.IsSuccessful)
            {
                throw new Exception("Server repley: Unsuccessful request");
            }

            return response.Data;
        }
    }
}
