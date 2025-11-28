using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static DateTime[] GetDatesOfWeek(int year, int weekNumber)
        {
            // ISO 8601: week 1 is the week with the first Thursday of the year
            var firstThursday = new DateTime(year, 1, 4);
            var calendar = CultureInfo.CurrentCulture.Calendar;

            // Get the first Monday of week 1
            int weekOfYear = calendar.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int daysOffset = (weekNumber - weekOfYear) * 7;

            var mondayOfWeek = firstThursday.AddDays(daysOffset).AddDays(-3);

            // Return the 7 days of the week
            return Enumerable.Range(0, 7).Select(d => mondayOfWeek.AddDays(d)).ToArray();
        }

        public async Task<IDictionary<string, int>> GetBookedPeopleCountAsync(int fishingSpotId, int weekNumber, int year)
        {
            var request = new RestRequest("bookings/booked-people-count");
            request.AddParameter<int>("fishingSpotId", fishingSpotId);
            request.AddParameter<int>("weekNumber", weekNumber);
            request.AddParameter<int>("year", year);

            var response = await _restClient.ExecuteAsync<IDictionary<string, int>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error getting booked people count. Message was {response.StatusDescription}");
            }

            return response.Data;
        }
    }
}
