using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VirtPub.Models;

namespace VirtPub.Services
{
    public class GameService
    {
        private HttpClient Client { get; }
        private readonly IConfiguration _configuration;

        public GameService(HttpClient client, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            client = new HttpClient(clientHandler);
            client = clientFactory.CreateClient("api");
            _configuration = configuration;
            Client = client;
        }

        public async Task<GameLinksModel> GetGameById(string id)
        {
            var response = await Client.GetAsync(
                $"api/v1.0/GameLinks/GetGameByid?id={id}");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <GameLinksModel>(responseStream);
        }


        public async Task<List<GameLinksModel>> GetGames()
        {
            var response = await Client.GetAsync(
                "api/v1.0/GameLinks");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <List<GameLinksModel>>(responseStream);
        }
    }
}
