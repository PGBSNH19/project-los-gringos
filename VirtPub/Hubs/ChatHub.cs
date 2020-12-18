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

        public async Task SendMessageToLobby(string message)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
            await AddUserToGroup();
        }

        public async Task AddUserToGroup()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            await Groups.AddToGroupAsync(Context.ConnectionId, "Table1");
        }
    }
}