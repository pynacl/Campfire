using System;
using System.Threading.Tasks;

namespace Campfire.Mobile.Services
{
    public interface IChatService
    {
        Task Connect();
        Task Disconnect();
        void ReceiveMessage(Action<string, string> GetMessageAndUser);
        Task SendMessage(string userId, string message);
    }
}
