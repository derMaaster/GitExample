using System;
using System.Collections.Generic;
using Full_Arch_UWP_Autofac.Helpers;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using ClassLibraryNetStandard;
using System.Diagnostics;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class OtherPage_ViewModel : NotificationBaseHelper
    {
        private readonly IDIClass dIClass1;

        public ObservableCollection<VMData> VMDataInfoSet { get; set; }
        public List<Actions> ListMyActions { get; set; }
        public List<Types> ListMyTypes { get; set; }


        public MyICommand<ToggleSwitch> ToggleSwitchToggled_Command { get; private set; }

        public OtherPage_ViewModel(IDIClass dIClass)
        {
            dIClass1 = dIClass;
            ToggleSwitchToggled_Command = new MyICommand<ToggleSwitch>(ToggleSwitchToggled);

            LoadControls();
        }

        private void ToggleSwitchToggled(ToggleSwitch toggleSwitch)
        {
            Debug.WriteLine("Toggle Switch Command was called");
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
                    Running = false
                },
                new VMData
                {
                    MyType = "TypeTwo",
                    ID = "2",
                    Qty = 1,
                    Action = "Stop",
                    Running = false
                }
            };
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
    public class VMData
    {
        public string MyType { get; set; }
        public string ID { get; set; }
        public double Qty { get; set; }
        public string Action { get; set; }
        public bool Running { get; set; }
    }
}
