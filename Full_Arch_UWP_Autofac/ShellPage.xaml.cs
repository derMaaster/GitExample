using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Full_Arch_UWP_Autofac.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Full_Arch_UWP_Autofac
{
    
    public sealed partial class ShellPage : Page
    {
        public Frame AppFrame { get { return Content; } }        
        public ShellPage()
        {
            this.InitializeComponent();
        }
        public ShellPage_ViewModel ViewModel { get { return (ShellPage_ViewModel)DataContext; } }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ViewModel.LoadAsync();
            base.OnNavigatedTo(e);
        }
    }
}
