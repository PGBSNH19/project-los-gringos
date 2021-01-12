using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VirtPub.Models;

namespace VirtPub.Services
{
    public class ScoreboardService
    {

        private HttpClient Client { get; }
        private readonly IConfiguration _configuration;

        public ScoreboardService(HttpClient client, IConfiguration configuration)
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