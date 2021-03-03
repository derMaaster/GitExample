using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryNetStandard.Helpers;

namespace ClassLibraryNetStandard
{
    public class BaseClass : INotifyPropertyChanged
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


        public async Task Run()
        {            
            IsOn = true;
            await Task.Delay(5000);
        }
        public async Task Stop()
        {
            await Task.Delay(300);
            IsOn = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
