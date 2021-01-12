using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using VirtPub.Models;

namespace VirtPub.Services
{
    public class UserService
    {
        private HttpClient Client { get; }
        private readonly IConfiguration _configuration;
        private static List<ConnectedUser> users = new List<ConnectedUser>();
        public UserService(HttpClient client, IConfiguration configuration)
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
        public List<ConnectedUser> GetUsersInTableById(string group)
        {
            return users.Where(x => x.Group == group).ToList();
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
    }
}