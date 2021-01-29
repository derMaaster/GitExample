using System;
using Full_Arch_UWP_Autofac.Helpers;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class ShellPage_ViewModel
    {
        private readonly INavigationService Navigation;
        public ShellPage_ViewModel(INavigationService navigation)
        {
            this.Navigation = navigation;
        }

        public Boolean OtherPageSelected
        {
            get { return Navigation.CurrentPage == "OtherPage"; }
            set
            {
                if (value)
                    Navigation.NavigateShellFrame("OtherPage");
            }
        }

        //public Boolean AnotherPageSelected
        //{
        //    get { return Navigation.CurrentPage == "AnotherPage"; }
        //    set
        //    {
        //        if (value)
        //            Navigation.NavigateShellFrame("AnotherPage");
        //    }
        //}
    }
}
