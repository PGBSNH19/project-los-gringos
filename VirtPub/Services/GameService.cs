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
        public HttpClient Client { get; }
        private readonly IConfiguration _configuration;

        public GameService(HttpClient client, IConfiguration configuration)
        {
            _configuration = configuration;
            Client = client;

            var baseAdress = _configuration.GetValue<Uri>("DevBackendURI");
            client.BaseAddress = baseAdress == null ? _configuration.GetValue<Uri>("ProdBackendURI") : baseAdress;
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

        public async Task<TableModel> GetTableById(string id)
        {
            var response = await Client.GetAsync(
                $"api/v1.0/Table/GetTableById?id={id}");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <TableModel>(responseStream);
        }

        public async Task<IEnumerable<TableModel>> GetTablesLinkedToGame(string id)
        {
            var response = await Client.GetAsync(
                $"api/v1.0/Table/GetTablesLinkedToGame?id={id}");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <IEnumerable<TableModel>>(responseStream);
        }

        public async Task<IEnumerable<TableModel>> GetTables()
        {
            var response = await Client.GetAsync(
                "api/v1.0/Table");

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <IEnumerable<TableModel>>(responseStream);
        }

        public async Task<string> CreateTable(GameLinksModel Game)
        {
            var table = new TableModel();
            table.id = Guid.NewGuid();
            table.isPrivate = false;
            table.game = Game;

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await Client.PostAsync(
                "api/v1.0/Table", data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
