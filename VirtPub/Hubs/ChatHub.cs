using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VirtPub.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatHub(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendMessageToGroup(string message, string group)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            await Clients.Group(group).SendAsync("ReceiveMessage", userName, message);
        }

        public async Task AddUserToGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId.ToString(), group);
            await Clients.GroupExcept(group, Context.ConnectionId).SendAsync("ReceiveMessage", _httpContextAccessor.HttpContext.User.Identity.Name, "Has joined");
        }

        public Task RemoveUserFromGroup(string group)
        {
            Clients.GroupExcept(group, Context.ConnectionId).SendAsync("ReceiveMessage", _httpContextAccessor.HttpContext.User.Identity.Name, "left");
            return Groups.RemoveFromGroupAsync(Context.ConnectionId.ToString(), group);
        }
    }
}