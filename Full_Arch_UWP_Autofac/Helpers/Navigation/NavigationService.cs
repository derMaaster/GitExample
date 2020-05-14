using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

//
namespace Full_Arch_UWP_Autofac.Helpers
{
    public class NavigationService : INavigationService
    {
        private readonly Frame frame;
        private readonly IViewModelBinder viewModelBinder;

        public NavigationService(IFrameProvider frameProvider, IViewModelBinder viewModelBinder)
        {
            frame = frameProvider.CurrentFrame;
            frame.Navigating += OnNavigating;
            frame.Navigated += OnNavigated;
            this.viewModelBinder = viewModelBinder;
        }

        protected virtual void OnNavigating(object sender, NavigatingCancelEventArgs e) { }
        protected virtual void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (e.Content == null)
                return;

            var view = e.Content as Page;
            if (view == null)
                throw new ArgumentException("View '" + e.Content.GetType().FullName +
                    "' should inherit from Page or one of its descendents.");

            viewModelBinder.Bind(view, e.Parameter);
        }
        public bool Navigate<TView>() where TView : Page
        {
            return frame.Navigate(typeof(TView));
        }
        public bool Navigate<TView, TViewModel>(object parameter = null) where TView : Page
        {
            var context = new NavigationContext(typeof(TViewModel), parameter);
            return frame.Navigate(typeof(TView), context);
        }


        public const string UnknownPage = "(Unknown)";
        public string CurrentPage
        {
            get
            {                
                var mainFrame = frame;
                if (mainFrame.Content == null)
                    return UnknownPage;

                var frameString = mainFrame.Content.ToString();

                return frameString;

            }
        }
    }
}