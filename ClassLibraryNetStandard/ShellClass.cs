using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using ClassLibraryNetStandard.Helpers;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ClassLibraryNetStandard
{
    public class ShellClass: INotifyPropertyChanged,IShellClass
    {
        public ExObservableCollection<BaseClass> BaseData;

        public ShellClass()
        {
            BaseData = new ExObservableCollection<BaseClass>();

            BaseClass firstClassA = new BaseClass(0, false);
            BaseClass secondClassA = new BaseClass(1, false);

            BaseData.Insert(0, firstClassA);
            BaseData.Insert(1, secondClassA);
        }

        public void Run(int row)
        {
            Task.Run(()=>BaseData[row].Run());
            
            //Debug.WriteLine("SHELL' " + BaseData[0].IsOn.ToString() + ",  " + BaseData[1].IsOn.ToString());
        }
        public void Stop(int row)
        {
            Task.Run(()=>BaseData[row].Stop());

            //Debug.WriteLine("SHELL' " + BaseData[0].IsOn.ToString() + ",  " + BaseData[1].IsOn.ToString());
        }
        public void StopAll()
        {
            Task.Run(()=>BaseData[0].Stop());
            Task.Run(() => BaseData[1].Stop());

            //Debug.WriteLine("DIClass' " + BaseData[0].IsOn.ToString() + ",  " + BaseData[1].IsOn.ToString());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }

}
