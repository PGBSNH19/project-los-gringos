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
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GameService _service;

        public ChatHub(IHttpContextAccessor httpContextAccessor, GameService service)
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
            Groups.AddToGroupAsync(Context.ConnectionId.ToString(), group);
            Clients.GroupExcept(group, Context.ConnectionId).SendAsync("ReceiveMessage", userName, "Has joined.");
        }

        public void RemoveUserFromGroup(string group)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            Clients.GroupExcept(group, Context.ConnectionId).SendAsync("ReceiveMessage", userName, "left.");
            Groups.RemoveFromGroupAsync(Context.ConnectionId.ToString(), group);
        }
    }
}