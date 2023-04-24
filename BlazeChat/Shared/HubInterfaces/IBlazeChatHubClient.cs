using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeChat.Shared.HubInterfaces
{
    public interface IBlazeChatHubClient
    {
        Task UserConnected(string username);
    }
}
