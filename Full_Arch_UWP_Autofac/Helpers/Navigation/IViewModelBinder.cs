using Windows.UI.Xaml;

namespace Full_Arch_UWP_Autofac.Helpers
{
    public interface IViewModelBinder
    {
        void Bind(FrameworkElement view, object viewModel);
    }
}
