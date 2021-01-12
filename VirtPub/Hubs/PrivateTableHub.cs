using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using VirtPub.Models;
using VirtPub.Services;

namespace VirtPub.Hubs
{
    public class PrivateTableHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserService _userService;

        public PrivateTableHub(IHttpContextAccessor httpContextAccessor,UserService userService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<ConnectedUser> UpdateUserList(string group)
        {
            return _userService.GetUsersInTableById(group);
        }

        public async void AddUserToUserList(string group)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            await Groups.AddToGroupAsync(Context.ConnectionId.ToString(), group);
            _userService.AddUserToUserList(userName, group, Context.ConnectionId);

            await Clients.Group(group).SendAsync("UpdateUserList");
        }

        public async void RemoveUserFromUserList(string group)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId.ToString(), group);
            _userService.RemoveUserFromUserList(userName);

            await Clients.GroupExcept(group, Context.ConnectionId).SendAsync("UpdateUserList");
        }
    }
}
