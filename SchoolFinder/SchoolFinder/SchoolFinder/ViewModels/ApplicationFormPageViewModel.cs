using Microsoft.EntityFrameworkCore.Storage;
using Prism.Commands;
using Prism.Navigation;
using SchoolFinder.Models;
using SchoolFinder.Service.Interfaces;

namespace SchoolFinder.ViewModels
{
    public class ApplicationFormPageViewModel : ViewModelBase
    {
        private readonly IDataBase _database;
        public ApplicationFormPageViewModel(INavigationService navigationService, IDataBase database) : base(navigationService)
        {
            _navigationService = navigationService;
            _database = database;
        }
        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        private DelegateCommand _navigationCommand;
        private INavigationService _navigationService;

        public DelegateCommand NavigationCommand =>
            _navigationCommand ?? (_navigationCommand = new DelegateCommand(ExcuteNavigationCommand));
        private StudentDetails _studentInfo;
       

        public StudentDetails StudentInfo 
        { 
            get { return _studentInfo; }
            set { SetProperty(ref _studentInfo, value); }
        }
        private async void ExecuteSaveCommand()
        {
            await _database.SaveStudentDetails(StudentInfo);

            await NavigationService.NavigateAsync("ApplicationStatusPage");
        }

        async void ExcuteNavigationCommand()
        {
            await NavigationService.NavigateAsync("LoginPage");
        }

    }
}
