using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using RestSharp;

namespace BaitM8s.APIClient
{
    public class TimeSlotAPIClient : ITimeSlotsDAO
    {
        #region attributes and constructor
        //The address of the API server
        private readonly string _apiUri;

        //the rest client from restsharp to call the server
        private readonly RestClient _restClient;

        public TimeSlotAPIClient(string apiUri)
        {
            _apiUri = apiUri;
            _restClient = new RestClient(apiUri);
        }
        #endregion

        public int Create(TimeSlot putAndTakePond)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeSlot> GetAll()
        {
            var request = new RestRequest("timeslots", Method.Get);
            var response = _restClient.Execute<IEnumerable<TimeSlot>>(request);
            if (response == null) throw new Exception("NO response from server");
            if (response.IsSuccessStatusCode) return response.Data;
            throw new Exception("Server reply: Unsuccessful request");
        }

        public IEnumerable<TimeSlot> GetByPondOwner(int pondOwnerId)
        {
            throw new NotImplementedException();
        }

        public TimeSlot? GetOne(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool Update(TimeSlot putAndTakePond)
        {
            throw new NotImplementedException();
        }
    }
}
