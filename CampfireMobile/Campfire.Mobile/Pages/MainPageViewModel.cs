using System;
using Campfire.Mobile.Helpers;
using Prism.Navigation;
using Xamarin.Forms;

namespace Campfire.Mobile.Pages
{
    public class MainPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public MainPageViewModel(INavigationService navigationService)
        : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Campfire";

        }

        public Command JoinCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var navigationParameters = new NavigationParameters
                    {
                        { "Username", Username }
                    };

                    await _navigationService.NavigateAsync("ChatPage", navigationParameters);

                });
            }
        }
    }
}
