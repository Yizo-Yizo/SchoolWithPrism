using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolFinder.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigation, IPageDialogService pageDialogService) : base(navigation, pageDialogService)
           
        {
            Title = "Main Page";
        }
    }
}
