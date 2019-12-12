using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Essentials;


namespace SchoolFinder.ViewModels
{
    public class ContactPageViewModel : BindableBase
    {
        public ContactPageViewModel()
        {

        }

        private DelegateCommand _mapCommand;
        private readonly Location locaiton;

        public DelegateCommand MapCommand =>
            _mapCommand ?? (_mapCommand = new DelegateCommand(ExecuteMapCommand));


        async void ExecuteMapCommand()
        {
            var location = new Location(34.0491, 18.6812);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Walking };

            await Map.OpenAsync(locaiton, options);
        }
    }
}
