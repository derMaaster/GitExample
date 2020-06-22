using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.Generic;
using System.Linq;

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

            viewModelBinder.Bind(view, e);
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


        // Additional Code added to example's NavigationSerice: in order to isolate the main window's frame from the internal Shellpage frame navigation
        public Frame ShellFrame;
        private readonly IDictionary<string, Type> pages_ = new Dictionary<string, Type>();
        private readonly IDictionary<string, Type> viewModels_ = new Dictionary<string, Type>();

        public void ConfigureBindings(string pageString, Type page, Type viewModel)
        {
            lock (pages_)
            {
                if (pages_.ContainsKey(pageString))
                    throw new ArgumentException("The specified page is already registered.");
                if (pages_.Values.Any(v => v == page))
                    throw new ArgumentException("The specified view has already been registered under another name.");
                pages_.Add(pageString, page);
                
            }
            lock (viewModels_)
            {
                if (viewModels_.ContainsKey(pageString))
                    throw new ArgumentException("The specified page is already registered.");
                if (viewModels_.Values.Any(v => v == viewModel))
                    throw new ArgumentException("The specified viewModel has already been registered under another name.");
                viewModels_.Add(pageString, viewModel);
            }
        }
        public bool NavigateShellFrame(string ToWhichString)
        {
            if (ShellFrame == null)
                SetShellFrame();

            Type page = pages_[ToWhichString];
            Type viewModel = viewModels_[ToWhichString];
            NavigationContext context= new NavigationContext(viewModel,null);
            
            return ShellFrame.Navigate(page, context);
        }
        private void SetShellFrame()
        {
            ShellFrame = ((Window.Current.Content as Frame)?.Content as ShellPage)?.AppFrame;
            ShellFrame.Navigated += OnNavigated;
        }


        // For Radiobutton Logic in ShellPage_ViewModel
        public const string UnknownPage = "(Unknown)";
        public string CurrentPage
        {
            get
            {                
                var mainFrame = ShellFrame;
                if (mainFrame == null || mainFrame.Content == null)
                    return UnknownPage;

                var frameString = mainFrame.Content.ToString();

                return frameString;

            }
        }
    }
}