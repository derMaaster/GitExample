using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;

namespace ClassLibraryNetStandard
{
    public class BaseClass:INotifyPropertyChanged
    {
        public int ID { get; set; }


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

        public BaseClass(int iD, bool ison)
        {
            ID = iD;
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
