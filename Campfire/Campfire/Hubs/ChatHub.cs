using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Campfire.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userId, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", userId, message);
        }
    }
}
