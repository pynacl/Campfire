using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace Campfire.Mobile.Services
{
    public class ChatService : IChatService
    {
        private readonly HubConnection hubConnection;

        public ChatService()
        {
            var ip = "localhost";
            if (Device.RuntimePlatform == Device.Android)
                ip = "10.0.2.2";

            hubConnection = new HubConnectionBuilder()
                .WithUrl($"http://{ip}:5000/ChatHub")
                .Build();

            //hubConnection = new HubConnectionBuilder().WithUrl("http://10.0.2.2:5000/ChatHub").Build();
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
