using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Full_Arch_UWP_Autofac.Helpers
{
    public interface IViewModelBinder
    {
        void Bind(FrameworkElement view, NavigationEventArgs e);
        //void Configure(string page, string viewModel);
    }
}
