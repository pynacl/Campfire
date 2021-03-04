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

        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        private ObservableCollection<Message> messages = new ObservableCollection<Message>();
        public ObservableCollection<Message> Messages
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

            InitializeChat();
        }

        private async void InitializeChat()
        {
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
                return new Command(async () =>
                {
                    if (Username != null && Message != null)
                    {
                        await _chatService.SendMessage(Username, Message);
                        AddMessageToList(Username, Message, true);
                    }
                });
            }
        }

        private void GetMessage(string username, string message)
        {
            AddMessageToList(username, message, false);
        }

        private void AddMessageToList(string username, string message, bool isOwner)
        {
            var tempMessageList = Messages.ToList();
            tempMessageList.Add(new Message { IsOwner = isOwner, Value = message, Username = username });
            Messages = new ObservableCollection<Message>(tempMessageList);
            Message = string.Empty;
        }
    }
}
