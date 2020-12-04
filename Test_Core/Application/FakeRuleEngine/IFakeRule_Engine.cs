using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Helpers;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace Test_Core.Application
{
    public interface IFakeRule_Engine:INotifyPropertyChanged
    {
        void StartRule(string ruleID);
        void StopRule(string ruleID);
    }
}
