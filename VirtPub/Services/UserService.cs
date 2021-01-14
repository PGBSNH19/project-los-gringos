using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using VirtPub.Models;

namespace VirtPub.Services
{
    public class UserService
    {
        private HttpClient Client { get; }
        private static readonly List<ConnectedUser> Users = new List<ConnectedUser>();
        public UserService(HttpClient client, IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("api");
            Client = client;
        }

        public List<ConnectedUser> GetUsersInTableById(string group)
        {
            return Users.Where(x => x.Group == group).ToList();
        }

        public void AddUserToUserList(string userName, string group, string connectionId)
        {
            try
            {
                var isUserAdmin = IsTableWithoutAdmin(group);

                var newUser = Users.FirstOrDefault(z => z.UserName == userName);

                if (newUser == null)
                {
                    Users.Add(new ConnectedUser()
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
            catch (Exception)
            {
                Console.WriteLine("Unable to add the user to the list: Users");
            }
        }

        public void SetNewScoreForUser(string userName, string score)
        {
            try
            {
                var parsedScore = int.Parse(score);
                Users.First(x => x.UserName == userName).Score = parsedScore;
            }
            catch (Exception)
            {
                return;
            }
        }

        public ConnectedUser GetTableAdmin(string group)
        {
            try
            {
                return Users.First(x => x.Group == @group && x.IsAdmin == true);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static bool IsTableWithoutAdmin(string group)
        {
            return !Users.Any(x => x.Group == @group && x.IsAdmin == true);
        }

        public void RemoveUserFromUserList(string userName)
        {
            try
            {
                var userToRemove = Users.First(x => x.UserName == userName);
                Users.Remove(userToRemove);

                if (userToRemove != null && userToRemove.IsAdmin && Users.Any(x => x.Group == userToRemove.Group))
                {
                    Users.FirstOrDefault(x => x.Group == userToRemove.Group).IsAdmin = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to remove the user from the list: Users");
            }
        }
    }
}