using System;
using System.Collections.Generic;
using Full_Arch_UWP_Autofac.Helpers;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using ClassLibraryNetStandard;
using System.Diagnostics;
using Windows.UI.Xaml.Controls.Primitives;
using System.ComponentModel;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class OtherPage_ViewModel:INotifyPropertyChanged 
    {
        private readonly IDIClass dIClass1;

        public ObservableCollection<VMData> VMDataInfoSet { get; set; }
        public List<Actions> ListMyActions { get; set; }
        public List<Types> ListMyTypes { get; set; }


        public MyICommand<ToggleSwitch> ToggleSwitchToggled_Command { get; private set; }
        public MyICommand<ToggleButton> ToggleButtonClicked_Command { get; private set; }
        public MyICommand<Button> ButtonClicked_Command { get; private set; }

        public OtherPage_ViewModel(IDIClass dIClass)
        {
            dIClass1 = dIClass;
            dIClass1.PropertyChanged += DIClass1_PropertyChanged;           
            ToggleButtonClicked_Command = new MyICommand<ToggleButton>(ToggleButtonClicked);
            ButtonClicked_Command = new MyICommand<Button>(ButtonClicked);

            LoadControls();
        }

        private void DIClass1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine("ViewModel PropertyChanged, sender.name: " + e.PropertyName.ToString());

            //...VMDataInfoSet["use baseClass sender instance to update specific VMDataInfoSet.Ison" ].IsOn = false;
        }

        private void ToggleButtonClicked(ToggleButton toggleButton)
        {
            string name = toggleButton.Name;
            int row = 0;

            Debug.WriteLine("Toggle Button " + name + " was clicked");

            switch (name)
            {
                case ("ToggleButtonOne"):
                    row = 0;
                    break;
                case ("ToggleButtonTwo"):
                    row = 1;
                    break;
            }

            // if the button was clicked to "on"/true, implement run(). Else, it was set to "off"/false, then stop()
            if (VMDataInfoSet[row].IsOn)
            {
                dIClass1.Run(row);
            }
            else
            {
                dIClass1.Stop(row);
            }

            Debug.WriteLine("ViewModel: " + VMDataInfoSet[0].IsOn.ToString() + ",  " + VMDataInfoSet[1].IsOn.ToString());

        }
        private void ButtonClicked(Button button)
        {
            string name = button.Name;

            Debug.WriteLine("Button " + name + " was clicked");

            if (name == "ButtonStop")
            {
                dIClass1.StopAll();
            }

            Debug.WriteLine("ViewModel' " + VMDataInfoSet[0].IsOn.ToString() + ",  " + VMDataInfoSet[1].IsOn.ToString());
        }
        private void LoadControls()
        {
            ListMyTypes = new List<Types>
            {
                new Types {ID = 1, MyType= "TypeOne"},
                new Types {ID = 2, MyType= "TypeTwo"},
            };
            ListMyActions = new List<Actions>
            {
                new Actions {ID = 1, Action= "Run"},
                new Actions {ID = 2, Action= "Stop"}
            };
            VMDataInfoSet = new ObservableCollection<VMData>
            {
                new VMData
                {
                    MyType = "TypeOne",
                    ID = "1",
                    Qty = 1,
                    Action = "Run",
                    IsOn = false
                },
                new VMData
                {
                    MyType = "TypeTwo",
                    ID = "2",
                    Qty = 1,
                    Action = "Stop",
                    IsOn = false
                }
            };            
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Actions
    {
        public int ID { get; set; }
        public string Action { get; set; }
    }
    public class Types
    {
        public int ID { get; set; }
        public string MyType { get; set; }
    }
    public class VMData : INotifyPropertyChanged
    {
        private string myType;
        private string iD;
        private double qty;
        private string action;
        private bool isOn;

        public string MyType
        {
            get { return myType; }
            set
            {
                myType = value;
                RaisePropertyChanged("MyType");
            }
        }
        public string ID
        {
            get { return iD; }
            set
            {
                iD = value;
                RaisePropertyChanged("ID");
            }
        }
        public double Qty 
        {
            get { return qty; }
            set
            {
                qty = value;
                RaisePropertyChanged("Qty");
            }
        }
        public string Action 
        {
            get { return action; }
            set
            {
                action = value;
                RaisePropertyChanged("Action");
            }
        }
        public bool IsOn 
        {
            get { return isOn; }
            set
            {
                isOn = value;
                RaisePropertyChanged("IsOn");
            }
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
