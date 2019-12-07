using Microsoft.EntityFrameworkCore.Storage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SchoolFinder.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SchoolFinder.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private IDatabase _database;

        private DelegateCommand _signUpCommand;
        private DelegateCommand SignUpCommand =>
            _signUpCommand ?? (_signUpCommand = new DelegateCommand(ExecuteSignUpCommand));

        public SignUpPageViewModel(INavigationService navigation, IPageDialogService pageDialogService) : base(navigation, pageDialogService)
        {

        }

        public Command FirstName { get; set; }
        public Command LastName { get; set; }
        public Command Email { get; set; }
        public Command Password { get; set; }
        public Command ConfirmPassword { get; set; }
        
        

        private async void ExecuteSignUpCommand()
        {
            LoginService service = new LoginService();
            var getLoginDetails = await service.CheckLoginIfExists(Email, Password);
            if (FirstName == null && LastName == null && Email == null && Password == null && ConfirmPassword == null)
            {
                await PageDialogService.DisplayAlertAsync("Login Successfull", "Username or Password is correct", "Okay", "Cancel");
            }
            else if (FirstName == null && Password == null)
            {
                await PageDialogService.DisplayAlertAsync("Login failed", "Enter your Email and Password before login", "Okay", "Cancel");
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }
    }
}
