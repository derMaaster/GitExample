using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Full_Arch_UWP_Autofac.Helpers;
using Test_Core.ServiceLayer;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    //
    public class MainPage_ViewModel:NotificationBaseHelper
    {
        public IService_DebugWriteString _ServiceDebugWriteString { get; }
        public MyICommand<Button> ButtonClickCommand { get; private set; }

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
            }
        }

    }
}
