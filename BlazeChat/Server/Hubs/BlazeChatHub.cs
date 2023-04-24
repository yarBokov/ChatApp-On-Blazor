using BlazeChat.Shared.HubInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace BlazeChat.Server.Hubs
{
    public class BlazeChatHub: Hub<IBlazeChatHubClient> , IBlazeChatHubServer 
    {
        public static ICollection<string> connectedUsers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        public BlazeChatHub()
        {

        }
        
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task ConnectUser(string username)
        {
            if (!connectedUsers.Contains(username))
            {
                connectedUsers.Add(username);

                await Clients.Others.UserConnected(username);
            }
        }
    }
}
