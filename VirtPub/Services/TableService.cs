using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VirtPub.Models;

namespace VirtPub.Services
{

    public class TableService
    {

        private HttpClient Client { get; }
        private readonly IConfiguration _configuration;

        public TableService(HttpClient client, IConfiguration configuration)
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
            table.gameID = Game.id;

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
            var data = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await Client.PostAsync(
                "api/v1.0/Table", data);

            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> RemoveTableByID(Guid id)
        {
            var response = await Client.DeleteAsync($"api/v1.0/Table?id={id}");
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}