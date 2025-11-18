using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    public class BookingAPIClient : IAPIClient<Booking>
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public BookingAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }



        public IEnumerable<Booking> GetAll()
        {
            var request = new RestRequest("bookings", Method.Get);
            var response = _restClient.Execute<IEnumerable<Booking>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving bookings. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public Booking? GetOne(int Id)
        {
            var request = new RestRequest($"bookings/{Id}", Method.Get);
            var response = _restClient.Execute<Booking>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving booking. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<int> CreateAsync(Booking booking)
        {
            var request = new RestRequest("bookings", Method.Post);
            request.AddJsonBody(booking);

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
