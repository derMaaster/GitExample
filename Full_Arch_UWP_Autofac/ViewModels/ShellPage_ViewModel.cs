using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
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
    }
}
