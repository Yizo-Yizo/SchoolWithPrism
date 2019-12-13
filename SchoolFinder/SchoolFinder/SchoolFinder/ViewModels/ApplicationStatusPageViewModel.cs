using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SchoolFinder.Models;
using SchoolFinder.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SchoolFinder.ViewModels
{
    public class ApplicationStatusPageViewModel : ViewModelBase
    {
        private readonly IDatabase _database;
       


        public ApplicationStatusPageViewModel(INavigationService navigationService, IDatabase database, IPageDialogService pageDialogService) : base(navigationService, pageDialogService )
        {
            _database = database;
            PageDialogService = pageDialogService;
        }

        private DelegateCommand _navigationCommand;
        public DelegateCommand NavigationCommand =>
            _navigationCommand ?? (_navigationCommand = new DelegateCommand(ExcuteNavigationCommand));

        async void ExcuteNavigationCommand()
        {
            await NavigationService.NavigateAsync("LoginPage");
        }

        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand =>
            _submitCommand ?? (_submitCommand = new DelegateCommand(ExcuteSubmitCommand));

        public new IPageDialogService PageDialogService { get; }

        public StudentDetails StudentInfo;
        async void ExcuteSubmitCommand()
        {
            var SavedDetails = await _database.SaveStudentDetailsAsync(StudentInfo);

            var url = "http://10.0.2.2:44349/api/StudentDetails";
            var client = new HttpClient();

            try
            {
                

                    var json = JsonConvert.SerializeObject(SavedDetails);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                await _database.SaveStudentDetailsAsync(SavedDetails);
                
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Exception", ex.Message, "OK");


            }

            await PageDialogService.DisplayAlertAsync("Submition Successfull", "Your Application has been submitted", "Okay", "Cancel");
            await NavigationService.NavigateAsync("MainPage");
        }
    }
}
