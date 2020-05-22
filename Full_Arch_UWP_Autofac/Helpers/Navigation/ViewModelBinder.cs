using System;
using Windows.UI.Xaml;
using System.Reflection;
using Windows.UI.Xaml.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace Full_Arch_UWP_Autofac.Helpers
{
    // every time a radiobutton is clicked, the view.DataContext is back to ShellPage_ViewModel
    // Thus, the bind() is called every time the radioButton is clicked. Thus, some boilerplate code below.

    public class ViewModelBinder : IViewModelBinder
    {
        private readonly IServiceProvider serviceProvider;
        public ViewModelBinder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Bind(FrameworkElement view, NavigationEventArgs e)
        {
            InitializeComponent(view);
            // Here was a check to see whether the view already has a DataContext
            //  ,but it always does, and incorrectly so as somehow, ShellPage_ViewModel
            //  is given to the page loaded within it's frame every time on selection
            var context = e.Parameter as NavigationContext;
            var viewModel = e.Parameter;
            if (context != null)
            {
                var viewModelType = context.ViewModelType;
                if (viewModelType != null)
                {
                    viewModel = serviceProvider.GetService(viewModelType);
                }

                var parameter = context.Parameter;
                //TODO: figure out what to do with parameter
            }

            view.DataContext = viewModel;
        }
        static void InitializeComponent(object element)
        {
            var method = element.GetType().GetTypeInfo()
                .GetDeclaredMethod("InitializeComponent");

            method?.Invoke(element, null);
        }
    }
}
