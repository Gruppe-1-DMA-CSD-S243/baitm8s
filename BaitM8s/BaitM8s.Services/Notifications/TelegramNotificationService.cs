using BaitM8s.Services.Notifications.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.Services.Notifications
{
    public class TelegramNotificationService : INotificationService
    {
        private readonly string _baseServiceUri;
        private readonly string _apiToken;
        private readonly string _chatId;
        private readonly RestClient _restClient;

        public TelegramNotificationService(string baseServiceUri, string apiToken, string chatId)
        {
            _baseServiceUri = baseServiceUri;
            _apiToken = apiToken;
            _chatId = chatId;
            _restClient = new RestClient(_baseServiceUri);
        }

        public async Task<bool> SendNotificationAsync(string message)
        {
            var request = new RestRequest("bot{apiToken}/sendMessage");
            request.AddUrlSegment("apiToken", _apiToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("chat_id", _chatId);
            request.AddParameter("text", message);

            var response = await _restClient.PostAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error sending telegram notification. Message was {response.StatusDescription}");
            }

            return true;
        }
    }
}
