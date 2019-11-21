using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using task3.Views;
using Xamarin.Forms;

namespace task3.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand toPage1;
        private DelegateCommand toPage2;
        private DelegateCommand toPage3;

        public DelegateCommand ToPage1 =>
            toPage1 ?? (toPage1 = new DelegateCommand(PushPage1));

        public DelegateCommand ToPage2 =>
            toPage2 ?? (toPage2 = new DelegateCommand(PushPage2));

        public DelegateCommand ToPage3 =>
            toPage3 ?? (toPage3 = new DelegateCommand(PushPage3));

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
           
        }

        private async  void PushPage1()
        {
            await NavigationService.NavigateAsync("Page1");
        }

        private async void PushPage2()
        {
            await NavigationService.NavigateAsync("Page2");
        }

        private async void PushPage3()
        {
            await NavigationService.NavigateAsync("Page3");
        }

    }
}
