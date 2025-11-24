using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Clients
{
    //TODO: Change to IAnglerDAO
    public class AnglerAPIClient : IAnglerAPIClient
    {
        private readonly string _apiBaseUri;
        private readonly RestClient _restClient;

        public AnglerAPIClient(string apiBaseUri)
        {
            _apiBaseUri = apiBaseUri;
            _restClient = new RestClient(_apiBaseUri);
        }

        public async Task<IEnumerable<AnglerDTO>> GetAllAsync()
        {
            var request = new RestRequest("anglers", Method.Get);
            var response = await _restClient.ExecuteAsync<IEnumerable<AnglerDTO>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving anglers. Message was {response.StatusDescription}");
            }

            return response.Data;
        }

        public async Task<AnglerDTO?> GetOneAsync(int Id)
        {
            var request = new RestRequest($"anglers/{Id}", Method.Get);

            var response = await _restClient.ExecuteAsync<AnglerDTO>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Error retrieving angler. Message was {response.StatusDescription}");
            }

            return response.Data;
        }
    }
}
