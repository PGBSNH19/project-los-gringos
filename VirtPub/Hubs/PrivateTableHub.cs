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
    public class PrivateTableHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GameService _service;

        public PrivateTableHub(IHttpContextAccessor httpContextAccessor, GameService service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<ConnectedUser> UpdateUserList(string group)
        {
            return _service.GetUsersInTableById(group);
        }

        public async void AddUserToUserList(string group)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            await Groups.AddToGroupAsync(Context.ConnectionId.ToString(), group);
            _service.AddUserToUserList(userName, group, Context.ConnectionId);

            await Clients.Group(group).SendAsync("UpdateUserList");
        }

        public async void RemoveUserFromUserList(string group)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId.ToString(), group);
            _service.RemoveUserFromUserList(userName);

            await Clients.GroupExcept(group, Context.ConnectionId).SendAsync("UpdateUserList");
        }
    }
}