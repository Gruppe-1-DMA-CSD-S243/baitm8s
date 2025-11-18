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
    public class AnglerAPIClient : IAPIClient<Angler>
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public AnglerAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }

        public IEnumerable<Angler> GetAll()
        {
            var request = new RestRequest("anglers", Method.Get);
            var response = _restClient.Execute<IEnumerable<Angler>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving anglers. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public Angler? GetOne(int Id)
        {
            var request = new RestRequest($"anglers/{Id}", Method.Get);
            var response = _restClient.Execute<Angler>(request);
            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving angler. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<int> CreateAsync(Angler angler)
        {
            throw new NotImplementedException();
        }
    }
}
