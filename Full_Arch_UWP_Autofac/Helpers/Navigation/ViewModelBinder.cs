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

            if (view.DataContext != null)
            {
                string viewDataContext = view.DataContext.ToString();
                string viewName = e.SourcePageType.Name;

                if(pages_[viewName] == viewDataContext)
                    return;
            }

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


        //Additional code:
        private readonly IDictionary<string, string> pages_= new Dictionary<string, string>();
        public void Configure(string page, string viewModel)
        {
            lock (pages_)
            {
                if (pages_.ContainsKey(page))
                    throw new ArgumentException("The specified page is already registered.");

                if (pages_.Values.Any(v => v == viewModel))
                    throw new ArgumentException("The specified view has already been registered under another name.");

                pages_.Add(page, viewModel);
            }
        }
    }
}
