using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Full_Arch_UWP_Autofac.Helpers
{
    public class DefaultFrameProvider : IFrameProvider
    {
        public Frame CurrentFrame
        {
            get
            {
                return (Window.Current.Content as Frame);
                //return ((Window.Current.Content as Frame)?.Content as ShellPage)?.AppFrame;
            }
        }
    }
}
