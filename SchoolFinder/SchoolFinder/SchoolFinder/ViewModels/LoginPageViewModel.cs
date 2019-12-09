using Microsoft.EntityFrameworkCore.Storage;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using Prism.Navigation;
using SchoolFinder.ServiceHandler;
using static System.Net.Mime.MediaTypeNames;
using Prism.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SchoolFinder.Service.Interfaces;

namespace SchoolFinder.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
       // private readonly IDatabase _database;
        public LoginPageViewModel(INavigationService navigationService, IDataBase database, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
          //  _navigationService = navigationService;
          //  _pageDialogService = pageDialogService;
        }
        
       // private readonly INavigationService _navigationService;
       // private readonly IPageDialogService _pageDialogService;

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        public Command Email { get; set; }
        public Command Password { get; set; }
        
         async void ExecuteLoginCommand()
        {
            LoginService service = new LoginService();
            var getLoginDetails = await service.CheckLoginIfExists(Email, Password);
            if (getLoginDetails)
            {
                 await PageDialogService.DisplayAlertAsync("Login Successfull", "Username or Password is correct", "Okay", "Cancel");
            }
            else if (Email == null && Password == null)
            {
                await PageDialogService.DisplayAlertAsync("Login failed", "Enter your Email and Password before login", "Okay", "Cancel");
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }

            await NavigationService.NavigateAsync("AboutPage");
        }

        private DelegateCommand _registerCommand;

        public DelegateCommand RegisterCommand =>
            _registerCommand ?? (_registerCommand = new DelegateCommand(ExecuteRegisterCommand));

        async void ExecuteRegisterCommand()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }
    }
}
