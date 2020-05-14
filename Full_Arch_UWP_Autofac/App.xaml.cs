using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Autofac;
using Full_Arch_UWP_Autofac.Views;
using Full_Arch_UWP_Autofac.ViewModels;
using Full_Arch_UWP_Autofac.Helpers;
using Test_Core.Domain;



//https://stackoverflow.com/questions/49843225/how-to-use-autofac-in-an-uwp-app

namespace Full_Arch_UWP_Autofac
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Container = ConfigureServices();

            this.Suspending += OnSuspending;
        }
        public static IContainer Container { get; set; }
        private IContainer ConfigureServices()
        {
            var containerBuilder = new ContainerBuilder();

            //  Registers all the platform-specific implementations of services.
            containerBuilder.RegisterType<Debug_WriteString>().As<IWriteString>().SingleInstance();

            //...Register ViewModels as well
            containerBuilder.RegisterType<ShellPage_ViewModel>().AsSelf();
            containerBuilder.RegisterType<MainPage_ViewModel>().AsSelf();
            containerBuilder.RegisterType<OtherPage_ViewModel>().AsSelf();

            containerBuilder.RegisterType<DefaultFrameProvider>().As<IFrameProvider>().SingleInstance();
            containerBuilder.RegisterType<ViewModelBinder>().As<IViewModelBinder>().SingleInstance();
            containerBuilder.RegisterType<AutofacServiceProvider>().As<IServiceProvider>();
            containerBuilder.RegisterType<NavigationService>().AsSelf().As<INavigationService>();

            var container = containerBuilder.Build();
            return container;
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }
            //**Activating navigation service
            var service = Container.Resolve<INavigationService>();

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate<ShellPage, ShellPage_ViewModel>();
                }
                // Ensure the current window is active
                Window.Current.Activate();
                
            }
        }
        public class AutofacServiceProvider : IServiceProvider 
        {
            public object GetService(Type serviceType)
            {
                return App.Container.Resolve(serviceType);
            }
        }

    /// <summary>
    /// Invoked when Navigation to a certain page fails
    /// </summary>
    /// <param name="sender">The Frame which failed navigation</param>
    /// <param name="e">Details about the navigation failure</param>
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
