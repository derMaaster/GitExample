using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using ClassLibraryNetStandard.Helpers;

namespace ClassLibraryNetStandard
{
    public class DIClass: INotifyPropertyChanged,IDIClass
    {
        public ObservableCollection<BaseClass> ClassesOfA;

        private string iNPCTest;
        public string INPCTest 
        {
            get { return iNPCTest; }
            set
            {
                iNPCTest = value;
                RaisePropertyChanged("DIClass: INPCTest");
            }
        }

        public DIClass()
        {
            ClassesOfA = new ObservableCollection<BaseClass>();

            //ClassA firstClassA = new ClassA("stringa", 1, 2,false);
            //ClassA secondClassA = new ClassA("stringb", 2, 3,false);

            BaseClass firstClassA = new BaseClass("stringa", 1, 2, false);
            BaseClass secondClassA = new BaseClass("stringb", 2, 3, false);

            ClassesOfA.Insert(0, firstClassA);
            ClassesOfA.Insert(1, secondClassA);

            //ClassesOfA[0].PropertyChanged += DIClass_PropertyChanged;
            //ClassesOfA[1].PropertyChanged += DIClass_PropertyChanged;
        }

        private void DIClass_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine("DIClass PropertyChanged, sender.name: " + e.PropertyName.ToString());
        }

        public void Run(int id)
        {
            //ClassesOfA[id].IsOn = true;

            ClassesOfA[id].Run();
            Debug.WriteLine("SHELL' " + ClassesOfA[0].IsOn.ToString() + ",  " + ClassesOfA[1].IsOn.ToString());
        }
        public void Stop(int id)
        {
            //ClassesOfA[id].IsOn = false;
            ClassesOfA[id].Stop();
            Debug.WriteLine("SHELL' " + ClassesOfA[0].IsOn.ToString() + ",  " + ClassesOfA[1].IsOn.ToString());
        }
        public void StopAll()
        {
            //ClassesOfA[0].IsOn = false;
            //ClassesOfA[1].IsOn = false;

            ClassesOfA[0].Stop();
            ClassesOfA[1].Stop();

            INPCTest = "test string";
            
            Debug.WriteLine("SHELL' " + ClassesOfA[0].IsOn.ToString() + ",  " + ClassesOfA[1].IsOn.ToString());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
