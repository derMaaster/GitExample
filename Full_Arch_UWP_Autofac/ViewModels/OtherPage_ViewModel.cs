using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Full_Arch_UWP_Autofac.Helpers;
using Test_Core.ServiceLayer;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class OtherPage_ViewModel:NotificationBaseHelper
    {
        public IService_GetSecretString _ServiceGetSecretString { get; }
        public MyICommand<Button> OtherButtonClickCommand { get; private set; }

        public OtherPage_ViewModel(IService_GetSecretString service_GetSecretString)
        {
            OtherButtonClickCommand = new MyICommand<Button>(ButtonClicked);
            _ServiceGetSecretString = service_GetSecretString;
        }

        private string _TextBoxText;
        public string TextBoxText
        {
            get { return _TextBoxText; }
            set { SetProperty(ref _TextBoxText,value); }
        }        

        public void ButtonClicked(Button button)
        {
            string buttonName = button.Name;
            switch (buttonName)
            {
                case "ButtonGetSecret":
                    TextBoxText = _ServiceGetSecretString.GetString();
                    break;
            }
        }
    }
}
