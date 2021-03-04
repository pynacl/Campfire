using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Campfire.Mobile.Services
{
    public class ChatService : IChatService
    {
        private readonly HubConnection hubConnection;

        public ChatService()
        {
            hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:44301/ChatHub").Build();
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
        }

        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }

        public async Task SendMessage(string userId, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", userId, message);
        }

        public void ReceiveMessage(Action<string, string> GetMessageAndUser)
        {
            hubConnection.On("ReceiveMessage", GetMessageAndUser);
        }
    }
}
