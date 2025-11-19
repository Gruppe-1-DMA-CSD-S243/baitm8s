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
    //old
    public class PutAndTakePondAPIClient : IPutAndTakePondDAO
    {
        #region attributes and constructor
        //The address of the API server
        private readonly string _apiUri;

        //the rest client from restsharp to call the server
        private readonly RestClient _restClient;

        public PutAndTakePondAPIClient(string apiUri)
        {
            _apiUri = apiUri;
            _restClient = new RestClient(apiUri);
        }
        #endregion
        public int Create(PutAndTakePond putAndTakePond)
        {
            var request = new RestRequest("putandtakeponds", Method.Post);
            request.AddJsonBody(putAndTakePond);

            var response = _restClient.Execute<int>(request);
            if (response == null) throw new Exception("NO response from server");
            if (!response.IsSuccessStatusCode) throw new Exception("Server reply: Unsuccessful request");
            return response.Data;
        }

        public bool Delete(int id)
        {
            var request = new RestRequest($"putandtakeponds/{id}", Method.Delete);

            var response = _restClient.Execute<bool>(request);
            if (response == null) throw new Exception("NO response from server");
            if (response.IsSuccessStatusCode) return response.Data;
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return false;
            throw new Exception("Server reply: Unsuccessful request");
        }

        public IEnumerable<PutAndTakePond> GetAll()
        {
            var request = new RestRequest("putandtakeponds", Method.Get);
            var response = _restClient.Execute<IEnumerable<PutAndTakePond>>(request);
            if (response == null) throw new Exception("NO response from server");
            if (response.IsSuccessStatusCode) return response.Data;
            throw new Exception("Server reply: Unsuccessful request");
        }

        public IEnumerable<PutAndTakePond> GetByPondOwner(int pondOwnerId)
        {
            var request = new RestRequest($"/{pondOwnerId}/PutAndTakePonds", Method.Get);
            var response = _restClient.Execute<IEnumerable<PutAndTakePond>>(request);
            if (response == null) throw new Exception("NO response from server");
            if (response.IsSuccessStatusCode) return response.Data;
            throw new Exception("Server reply: Unsuccessful request");
        }

        public PutAndTakePond? GetOne(string phoneNumber)
        {
            var request = new RestRequest($"putandtakeponds/{phoneNumber}", Method.Get);
            var response = _restClient.Execute<PutAndTakePond>(request);
            if (response == null) throw new Exception("NO response from server");
            if (response.IsSuccessStatusCode) return response.Data;
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return null;
            throw new Exception("Server reply: Unsuccessful request");
        }

        public bool Update(PutAndTakePond putAndTakePond)
        {
            if (putAndTakePond == null) throw new ArgumentNullException(nameof(putAndTakePond));
            var request = new RestRequest($"blogposts/{putAndTakePond.PondNumber}", Method.Put);
            request.AddJsonBody(putAndTakePond);

            var response = _restClient.Execute<bool>(request);
            if (response == null) throw new Exception("NO response from server");
            if (response.IsSuccessStatusCode) return response.Data;
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return false;
            throw new Exception("Server reply: Unsuccessful request");
        }
    }
}
