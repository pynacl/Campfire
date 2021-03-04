using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Campfire.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAsync(string userId, string message)
        {
            await Clients.All.SendAsync("ReceivedMessage");
        }
    }
}
