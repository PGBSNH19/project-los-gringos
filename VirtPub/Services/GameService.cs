using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VirtPub.Models;

namespace VirtPub.Services
{
    public class GameService
    {
        private HttpClient Client { get; }
        private static List<ConnectedUser> users = new List<ConnectedUser>();
        private readonly IConfiguration _configuration;

        public GameService(HttpClient client, IConfiguration configuration)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);

            _configuration = configuration;
            Client = client;

            var baseAdress = _configuration.GetValue<Uri>("DevBackendURI");
            client.BaseAddress = baseAdress == null ? _configuration.GetValue<Uri>("ProdBackendURI") : baseAdress;
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
