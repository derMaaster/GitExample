using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;

namespace ClassLibraryNetStandard
{
    public class BaseClass:INotifyPropertyChanged
    {
        public string StringA { get; set; }
        public int IntA { get; set; }
        public int Qty { get; set; }


        private bool isOn;
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                RaisePropertyChanged("BaseClass:IsOn");
            }
        }

        public BaseClass(string strA, int intA, int qty, bool ison)
        {
            StringA = strA;
            IntA = intA;
            Qty = qty;
            IsOn = ison;
        }


        public void Run() 
        {
            Debug.WriteLine("ClassA Run()");
            IsOn = true;
        }
        public void Stop()
        {
            Debug.WriteLine("ClassA Stop()");
            IsOn = false;
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
