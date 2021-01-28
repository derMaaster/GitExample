using System;
using System.Collections.Generic;
using Full_Arch_UWP_Autofac.Helpers;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using ClassLibraryNetStandard;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class OtherPage_ViewModel : NotificationBaseHelper
    {
        private readonly IDIClass dIClass1;

        public ObservableCollection<VMData> DataInfoSet { get; set; }
        public List<ASelection> ListSelectionA { get; set; }
        public List<BSelection> ListSelectionB { get; set; }


        public MyICommand<ToggleSwitch> ToggleSwitchToggled_Command { get; private set; }

        public OtherPage_ViewModel(IDIClass dIClass)
        {
            dIClass1 = dIClass;
            ToggleSwitchToggled_Command = new MyICommand<ToggleSwitch>(ToggleSwitchToggled);

            LoadControls();
        }

        private void ToggleSwitchToggled(ToggleSwitch toggleSwitch)
        {
            //string comboboxSelection = comboBox.SelectedItem.ToString();

            //switch (comboboxSelection)
            //{
            //    case "ATM":
            //        MainListData = KryKarre();
            //        break;
            //    case "Mense":
            //        MainListData = KryMense();
            //        break;
            //    case "InstantDoubleString":
            //        MainListData = InstantDoubleString();
            //        break;
            //}
        }

        private void LoadControls()
        {
            ListSelectionB = new List<BSelection>
            {
                new BSelection {ID = 1, MyType= "TypeOne"},
                new BSelection {ID = 2, MyType= "TypeTwo"},
            };

            ListSelectionA = new List<ASelection>
            {
                new ASelection {ID = 1, Action= "Run"},
                new ASelection {ID = 2, Action= "Stop"}
            };

            DataInfoSet = new ObservableCollection<VMData>
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

    public class ASelection
    {
        public int ID { get; set; }
        public string Action { get; set; }
    }
    public class BSelection
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
