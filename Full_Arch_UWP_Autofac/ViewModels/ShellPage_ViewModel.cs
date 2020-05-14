using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Full_Arch_UWP_Autofac.Helpers;
using Full_Arch_UWP_Autofac.Views;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class ShellPage_ViewModel
    {
        private readonly INavigationService Navigation;
        public ShellPage_ViewModel(INavigationService navigation)
        {
            this.Navigation = navigation;
        }

        public Boolean MainPageSelected
        {
            get { return Navigation.CurrentPage == "Main_Page"; }
            set
            {
                if (value)
                    Navigation.Navigate<MainPage,MainPage_ViewModel>();
            }
        }

        public Boolean OtherPageSelected
        {
            get { return Navigation.CurrentPage == "Other_Page"; }
            set
            {
                if (value)
                    Navigation.Navigate<OtherPage,OtherPage_ViewModel>();
            }
        }


    }
}
