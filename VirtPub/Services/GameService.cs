using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VirtPub.Models;

namespace VirtPub.Services
{
    public class GameService
    {
        public HttpClient Client { get; }

        public GameService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://pubtesterbackend.azurewebsites.net/");
            Client = client;
        }

        public async Task<IEnumerable<GameModel>> GetGames()
        {
            var response = await Client.GetAsync(
                "api/v1.0/GameLinks");

            using var responseStream = await response.Content.ReadAsStreamAsync();
            
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<GameModel>>(responseStream);
        }
    }
}