using Microsoft.AspNetCore.SignalR;

namespace BlazeChat.Server.Hubs
{
    public interface IBlazeChatHubClient
    {
        void ReceiveMessage(string message);
    }

    public class BlazeChatHub: Hub<IBlazeChatHubClient> 
    {
        public BlazeChatHub()
        {

        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
