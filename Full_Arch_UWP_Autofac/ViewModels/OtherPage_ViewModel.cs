using System;
using Windows.UI.Xaml.Controls;
using Full_Arch_UWP_Autofac.Helpers;
using Test_Core.Application;
using Windows.Storage;
using Test_Core.Repositories;
using System.Threading.Tasks;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class OtherPage_ViewModel:NotificationBaseHelper
    {
        public IService_GetSecretString ServiceGetSecretString_ { get; }
        public IFileAccess fileAccess;
        public MyICommand<Button> OtherButtonClickCommand { get; private set; }

        public OtherPage_ViewModel()
        {
            OtherButtonClickCommand = new MyICommand<Button>(ButtonClicked);
            ServiceGetSecretString_ = new ServiceGetSecretString();
            fileAccess = new FileAccess();
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
                    TextBoxText = ServiceGetSecretString_.GetString();
                    break;
                case "ButtonGetNetStandardFolder":
                    TextBoxText = GetNetStandardFolder();
                    break;
                case "ButtonCreateFolder":
                    TextBoxText = CreateFolder();
                    break;
            }
        }
        public async Task<string> CreateFileInStorageFolder()
        {
            //                case "ButtonGetAppStorageFolder":
            //        TextBoxText = CreateFileInStorageFolder();
            //break;

            UWPStorageFolder uWPStorageFolder = new UWPStorageFolder();
            var result = await uWPStorageFolder.CreateFileInStorageFolder();
            //var resultString = await result;

            return result;
        }
        public string GetNetStandardFolder()
        {
            //bool result = fileAccess.CreateFileTest();
            //return result.ToString();
            return "what";
        }
        public string CreateFolder()
        {
            string result = fileAccess.CreateFileTest();
            return result;
        }

    }
}
