using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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
        private readonly IDataBase _database;
        private INavigationService _navigationService;


        public ApplicationStatusPageViewModel(INavigationService navigationService, IDataBase database) : base(navigationService)
        {
            _navigationService = navigationService;
            _database = database;
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

        public StudentDetails StudentInfo;
        async void ExcuteSubmitCommand()
        {
            var SavedDetails = await _database.SavedStudentDetails(StudentInfo);

            var url = "http://10.0.2.2:44349/StudentDetails";
            var client = new HttpClient();

            try
            {
                foreach (StudentDetails Saved in SavedDetails)
                {

                    var json = JsonConvert.SerializeObject(unPosted);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                    unPosted.Posted = true;

                    await App.Database.SaveItemAsync(unPosted);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "OK");


            }
        }
    }
}
