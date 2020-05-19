using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Full_Arch_UWP_Autofac.Helpers;
using Test_Core.DataAdaptorLayer;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    //
    public class MainPage_ViewModel
    {
        public MyICommand<Button> ButtonClickCommand { get; private set; }
        public MainPage_ViewModel()
        {
            ButtonClickCommand = new MyICommand<Button>(ButtonClicked);
        }
        public void ButtonClicked(Button button)
        {
            string CurrContent = button.Content.ToString();
            switch (CurrContent)
            {
                case "DoDebug":

                    // get instance of DataAdaptor, which access the Domain DebugWriteString


                    Debug.WriteLine("toets geslaag");
                    break;
            }
        }

    }
}
