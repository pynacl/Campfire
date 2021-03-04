using System;
using Campfire.Mobile.Helpers;
using Prism.Navigation;

namespace Campfire.Mobile.Pages
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigationService)
        : base(navigationService)
        {
            Title = "Campfire";
        }
    }
}
