using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtPub.Models;
using VirtPub.Services;

namespace VirtPub.Hubs
{
    public class Scoreboard : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GameService _service;

        public Scoreboard(IHttpContextAccessor httpContextAccessor, GameService service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        public void SendMessageToGroup(string message, string group)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            Clients.Group(group).SendAsync("ReceiveMessage", userName, message);
        }

        public void AddUserToGroup(string group)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            
            _service.AddUserToUserList(userName, group, Context.ConnectionId);
        }

        public void RemoveUserFromGroup(string group)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            _service.RemoveUserFromUserList(userName);
        }
    }
}