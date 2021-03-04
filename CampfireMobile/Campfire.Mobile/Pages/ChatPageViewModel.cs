using System;
using Campfire.Mobile.Helpers;
using Campfire.Mobile.Services;
using Prism.Navigation;

namespace Campfire.Mobile.Pages
{
    public class ChatPageViewModel : BaseViewModel
    {
        private readonly IChatService _chatService;

        public ChatPageViewModel(INavigationService navigationService,
            IChatService chatService) : base (navigationService)
        {
            Title = "Chat";
            _chatService = chatService;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await _chatService.Connect();
        }
    }
}
