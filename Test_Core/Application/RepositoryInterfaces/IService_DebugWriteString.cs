using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Test_Core.Domain;
using Test_Core.Helpers;

namespace Test_Core.Application
{
    public interface IService_DebugWriteString: INotifyPropertyChanged
    {
        bool GetStatusBool();
        void WriteString(string stringMessage);
    }
}
