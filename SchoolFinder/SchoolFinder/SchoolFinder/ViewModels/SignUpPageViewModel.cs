using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SchoolFinder.Models;
using SchoolFinder.Service;
using SchoolFinder.Service.Interfaces;
using SchoolFinder.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolFinder.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDatabase database)
            : base(navigationService, pageDialogService)
        {
            _database = database;
            CurrentUser = new User();
        }


        private User _user;
        private IDatabase _database;
       

        public User CurrentUser
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }



        private DelegateCommand _signUpCommand;

        public DelegateCommand SignUpCommand =>
            _signUpCommand ?? (_signUpCommand = new DelegateCommand(ExecuteSignUpCommand));
      
        async void ExecuteSignUpCommand()
        {
           
            await _database.SaveUserAsync(CurrentUser);
            LoginService service = new LoginService();
            var getLoginDetails = await service.CheckLoginIfExists(CurrentUser.Email, CurrentUser.Password);

         
            if (CurrentUser.FirstName == null && CurrentUser.LastName == null && CurrentUser.Email == null && CurrentUser.Password == null && CurrentUser.ConfirmPassword == null)
            {
                await PageDialogService.DisplayAlertAsync("Login Successfull", "Username or Password is correct", "Okay", "Cancel");
                await NavigationService.NavigateAsync("AboutPage");
            }
            else if (CurrentUser.FirstName == null && CurrentUser.Password == null)
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
