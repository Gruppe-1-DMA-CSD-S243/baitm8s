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
    public class BookingAPIClient : IAPIClient
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public BookingAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            var request = new RestRequest("bookings", Method.Get);
            var response = _restClient.Execute<IEnumerable<Booking>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error organizing notes provided. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public Booking? GetBooking(int id)
        {
            var request = new RestRequest($"bookings/{id}", Method.Get);
            var response = _restClient.Execute<Booking>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error organizing notes provided. Message was {response.StatusDescription}");
            }

            return response.Data;
        }
    }
}
