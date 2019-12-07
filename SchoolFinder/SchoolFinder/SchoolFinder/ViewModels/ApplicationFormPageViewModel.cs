using Microsoft.EntityFrameworkCore.Storage;
using Prism.Commands;
using Prism.Navigation;
using SchoolFinder.Models;

namespace SchoolFinder.ViewModels
{
    public class ApplicationFormPageViewModel : ViewModelBase
    {
        private IDatabase _database;
        public ApplicationFormPageViewModel(INavigationService navigationService, IDatabase database) : base(navigationService)
        {

            _database = database;
        }
        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        private StudentDetails _studentInfo;
       

        public StudentDetails StudentInfo 
        { 
            get { return _studentInfo; }
            set { SetProperty(ref _studentInfo, value); }
        }
        private async void ExecuteSaveCommand()
        {
            await _database.SaveStudentDetails(StudentInfo);

            StudentInformation();

            await NavigationService.NavigateAsync("ApplicationStatusPage");
        }
    }
}
