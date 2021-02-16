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
            IsOn = true;
        }
        public void Stop()
        {
            IsOn = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
