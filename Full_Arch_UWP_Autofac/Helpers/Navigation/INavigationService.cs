using System;
using Windows.UI.Xaml.Controls;

namespace Full_Arch_UWP_Autofac.Helpers
{
    public interface INavigationService
    {
        bool Navigate<TView>() where TView : Page;
        bool Navigate<TView, TViewModel>(object parameter = null) where TView : Page;


        // Additions:
        void ConfigureBindings(string pageString, Type page, Type viewModel);
        bool NavigateShellFrame(string ToWhichString);
        string CurrentPage { get; }
    }
}
