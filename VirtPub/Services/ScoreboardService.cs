using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VirtPub.Models;

namespace VirtPub.Services
{
    public class ScoreboardService
    {

        private HttpClient Client { get; }

        public ScoreboardService(HttpClient client, IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("api");
            Client = client;
        }
        public async Task<List<ScoreboardModel>> GetScoreboardByGameId(string id)
        {
            var response = await Client.GetAsync(
              $"api/v1.0/ScoreBoard/{id}");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <List<ScoreboardModel>>(responseStream);
        }
    }

}