using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolFinder.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        
        private DelegateCommand _navigationCommand;
        private INavigationService _navigationService;

        public DelegateCommand NavigationCommand =>
            _navigationCommand ?? (_navigationCommand = new DelegateCommand(ExcuteNavigationCommand));
        /* public AboutPageViewModel(INavigationService navigationServe)
         {

         }*/

        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("ApplicationFormPage");
        }

        async void ExcuteNavigationCommand()
        {
            await NavigationService.NavigateAsync("LoginPage");
        }

        public AboutPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _navigationService = navigationService;

        }
    }
}
