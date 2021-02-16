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
    public class DIClass: INotifyPropertyChanged,IDIClass
    {
        public ExObservableCollection<BaseClass> ClassesOfA;

        public DIClass()
        {
            ClassesOfA = new ExObservableCollection<BaseClass>();

            BaseClass firstClassA = new BaseClass(0, false);
            BaseClass secondClassA = new BaseClass(1, false);

            ClassesOfA.Insert(0, firstClassA);
            ClassesOfA.Insert(1, secondClassA);
        }

        public void Run(int row)
        {
            ClassesOfA[row].Run();
            Debug.WriteLine("SHELL' " + ClassesOfA[0].IsOn.ToString() + ",  " + ClassesOfA[1].IsOn.ToString());
        }
        public void Stop(int row)
        {
            ClassesOfA[row].Stop();
            Debug.WriteLine("SHELL' " + ClassesOfA[0].IsOn.ToString() + ",  " + ClassesOfA[1].IsOn.ToString());
        }
        public void StopAll()
        {
            ClassesOfA[0].Stop();
            ClassesOfA[1].Stop();
            
            Debug.WriteLine("DIClass' " + ClassesOfA[0].IsOn.ToString() + ",  " + ClassesOfA[1].IsOn.ToString());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
