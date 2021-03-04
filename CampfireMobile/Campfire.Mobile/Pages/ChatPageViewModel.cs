using System;
using Campfire.Mobile.Helpers;
using Campfire.Mobile.Services;
using Prism.Navigation;

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
        }
    }
}
