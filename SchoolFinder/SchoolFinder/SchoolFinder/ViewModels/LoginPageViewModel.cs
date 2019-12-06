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

namespace SchoolFinder.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private IDatabase _database;

        private DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        public LoginPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
        }

       

            Email.ReturnCommand = new Command(() => Email.Focus());
            Entry_Second.ReturnCommand = new Command(() => Entry_Third.Focus());
        
        private async void ExecuteLoginCommand()
        {
            LoginService service = new LoginService();
            var getLoginDetails = await service.CheckLoginIfExists(Email.Focus, Pass.Focus);
            if (getLoginDetails)
            {
                 await _dialogService.DisplayAlert("Login Successfull", "Username or Password is correct", "Okay", "Cancel");
            }
            else if (Email.Focus == null && Pass.Focus == null)
            {
                await _dialogService.DisplayAlert("Login failed", "Enter your Email and Password before login", "Okay", "Cancel");
            }
            else
            {
                await _dialogService.DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }
    }
}
