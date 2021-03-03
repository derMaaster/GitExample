using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ClassLibraryNetStandard
{
    public interface IShellClass:INotifyPropertyChanged
    {
        void StopAll();
        void Run(int id);
        void Stop(int id);
    }
}
