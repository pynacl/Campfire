using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Campfire.Mobile.Helpers;
using Campfire.Mobile.Models;
using Campfire.Mobile.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace Campfire.Mobile.Pages
{
    public class ChatPageViewModel : BaseViewModel
    {
        private readonly IChatService _chatService;
        private readonly INavigationService _navigationService;

        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string userMessage;
        public string UserMessage
        {
            get => userMessage;
            set => SetProperty(ref userMessage, value);
        }

        private IEnumerable<Message> messages;
        public IEnumerable<Message> Messages
        {
            get => messages;
            set => SetProperty(ref messages, value);
        }

        public ChatPageViewModel(INavigationService navigationService,
            IChatService chatService) : base (navigationService)
        {
            Title = "Chat";
            _chatService = chatService;
            _navigationService = navigationService;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var username = parameters.GetValue<string>("Username");
            if (username == null)
            {
                // invalid username, go back
                await _navigationService.GoBackAsync();
            }
            Username = username;

            InitializeChat();
        }

        private async void InitializeChat()
        {
            Messages = new List<Message>();
            try
            {
                _chatService.ReceiveMessage(GetMessage);
                await _chatService.Connect();
            }
            catch (Exception exception) 
            {
                // TODO: handle this better by not catching Exception
                throw;
            }
            
        }

        public Command SendMessageCommand
        {
            get
            {
                return new Command(() =>
                {
                    _chatService.SendMessage(Username, UserMessage);
                    AddMessage(Username, UserMessage, true);
                });
            }
        }

        private void GetMessage(string username, string message)
        {
            AddMessage(username, message, false);
        }

        private void AddMessage(string username, string message, bool isOwner)
        {
            var tempList = Messages.ToList();
            tempList.Add(new Message { IsOwner = isOwner, Value = message, Username = username });
            Messages = new List<Message>(tempList);
            UserMessage = string.Empty;
        }
    }
}
