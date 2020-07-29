using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Full_Arch_UWP_Autofac.Helpers;
using Test_Core.Application;
using System.Collections.ObjectModel;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System;
using Windows.UI.Xaml;
using Windows.UI.Core;
using Windows.ApplicationModel.VoiceCommands;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    //
    public class MainPage_ViewModel:NotificationBaseHelper
    {
        CancellationTokenSource cts;
        CancellationToken token;
        System.Timers.Timer aTimer;
        int LoopCounter;

        public IService_DebugWriteString _ServiceDebugWriteString { get; }
        public MyICommand<Button> ButtonClickCommand { get; private set; }
        public ObservableCollection<string> ListData { get; set; } = new ObservableCollection<string>();

        public MainPage_ViewModel(IService_DebugWriteString i_DebugWriteString)
        {
            ButtonClickCommand = new MyICommand<Button>(ButtonClicked);
            _ServiceDebugWriteString = i_DebugWriteString;
        }

        private string _TextBoxText;
        public string TextBoxText
        {
            get { return _TextBoxText; }
            set { SetProperty(ref _TextBoxText, value); }
        }

        
        public void ButtonClicked(Button button)
        {
            string buttonName = button.Name;
            switch (buttonName)
            {
                case "ButtonDoDebug":
                    _ServiceDebugWriteString.WriteString(TextBoxText);
                    break;
                case "ButtonRunLoopTest":
                    StartLoopProcedure();
                    break;
                case "ButtonCallCancellationToken":
                    CallSourceCancel();
                    break;
            }
        }


        public void StartLoopProcedure()
        {
            LoopCounter = 0;
            ListData.Add(DateTime.Now.ToString() + "# " + LoopCounter.ToString() + ": StartLoopProcedure Called");
            
            cts = new CancellationTokenSource();
            token = cts.Token;

            ListData.Add(DateTime.Now.ToString() + "# " + LoopCounter.ToString() + ": Before Task.Run of Loop");
            Task.Run(()=> WorkLoopAsync().ConfigureAwait(false));

            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(DoTimerWork);
            aTimer.Enabled = true;

        }
        public void DoTimerWork(object source, ElapsedEventArgs e)
        {
            LoopCounter++;
            if (!token.IsCancellationRequested)
            {
                _ = WriteUpdateToUI();
            }
        }
        public void StopTimerWork()
        {
            cts.Dispose();
            aTimer.Stop();
            aTimer.Dispose();
            _ = WriteMsgToUI(DateTime.Now.ToString() + " " + ": cts.Disposed, Timer.Disposed");
        }
        public void CallSourceCancel()
        {
            cts.Cancel();
            ListData.Add(DateTime.Now.ToString() + "#" + ": CancellationSource CANCEL called");
        }
        public async Task WorkLoopAsync()
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    StopTimerWork();
                    return;
                }
                await Task.Delay(100);
            }            
        }
        public async Task WriteUpdateToUI()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                ListData.Add(DateTime.Now.ToString() + "# " + LoopCounter.ToString() + ": WorkLoop is running");
            });
        }
        public async Task WriteMsgToUI(string msg)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                ListData.Add(msg);
            });
        }


    }
}
