using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using SchoolFinder.Models;
using SchoolFinder.Service.Interfaces;
using SchoolFinder.ServiceHandler;

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
                await PageDialogService.DisplayAlertAsync("Register Successfull", "Enter your details", "Okay", "Cancel");
                await NavigationService.NavigateAsync("AboutPage");
            }
            else if (CurrentUser.FirstName == null && CurrentUser.Password == null)
            {
                await PageDialogService.DisplayAlertAsync("Registration failed", "Already have an account", "Okay", "Cancel");
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("Registration successful", "Enjoy", "Okay", "Cancel");
            }
        }
    }
}
