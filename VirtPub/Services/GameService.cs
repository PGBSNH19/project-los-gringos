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

        public List<ConnectedUser> GetUsersInTableById(string group)
        {
            return users.Where(x => x.Group == group).ToList();
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

        public void AddUserToUserList(string userName, string group, string connectionId)
        {
            try
            {
                var isUserAdmin = IsTableWithoutAdmin(group);

                var newUser = users.Where(z => z.UserName == userName).FirstOrDefault();

                if (newUser == null)
                {
                    users.Add(new ConnectedUser()
                    {
                        UserName = userName,
                        ConnectionId = connectionId,
                        Group = group,
                        IsAdmin = isUserAdmin
                    });
                }
                else
                {
                    newUser.ConnectionId = connectionId;
                    newUser.Group = group;
                    newUser.IsAdmin = isUserAdmin;
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Unable to add the user to the list: Users");
            }
        }

        private bool IsTableWithoutAdmin(string group)
        {
            if (users.Where(x => x.Group == group && x.IsAdmin == true).Count() == 0)
                return true;

            return false;
        }

        public void RemoveUserFromUserList(string userName)
        {
            try
            {
                var userToRemove = users.Where(x => x.UserName == userName).First();
                users.Remove(userToRemove);

                if (userToRemove != null && userToRemove.IsAdmin && users.Where(x => x.Group == userToRemove.Group).Count() > 0)
                {
                    users.Where(x => x.Group == userToRemove.Group).FirstOrDefault().IsAdmin = true;
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Unable to remove the user from the list: Users");
            }
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
