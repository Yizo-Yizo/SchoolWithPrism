using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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

        public AboutPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "About";
           
        }

        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("ApplicationFormPage");
        }
    }
}
