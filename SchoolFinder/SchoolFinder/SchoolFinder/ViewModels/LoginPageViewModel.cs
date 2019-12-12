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
using SchoolFinder.Models;

namespace SchoolFinder.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
       
        public LoginPageViewModel(INavigationService navigationService,IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            CurrentUser = new User();
        }

        private readonly Service.Interfaces.IDatabase _database;
        private User _user;

        public User CurrentUser
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));
        
         async void ExecuteLoginCommand()
        {
            await _database.SaveUserAsync(CurrentUser);
            LoginService service = new LoginService();
            var getLoginDetails = await service.CheckLoginIfExists(CurrentUser.Email, CurrentUser.Password);
            if (getLoginDetails)

            {
                 await PageDialogService.DisplayAlertAsync("Login Successfull", "Username or Password is correct", "Okay", "Cancel");
            }
            else if (CurrentUser.Email == null && CurrentUser.Password == null)
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
            await NavigationService.NavigateAsync("SignUpPage");
        }
    }
}
