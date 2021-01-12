using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Full_Arch_UWP_Autofac.Helpers;
using System.Collections.ObjectModel;
using Test_Core.Application;
using System.Diagnostics;
//using Test_Core.Domain;

using Windows.UI.Xaml.Controls;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class FakeRulePage_ViewModel:NotificationBaseHelper
    {
        private readonly IFakeRule_Engine _fakeRuleEngine;

        public ObservableCollection<VMRule_Data> RBTRules { get; set; }
        public static List<BidOffer> ListTradeAction { get; set; }
        public static List<OptionRules> Rules { get; set; }

        public MyICommand<ToggleSwitch> ToggleSwitchToggled_Command { get; private set; }

        public FakeRulePage_ViewModel(
            IFakeRule_Engine fakeRule_Engine)
        {
            _fakeRuleEngine = fakeRule_Engine;
            _fakeRuleEngine.PropertyChanged += FakeRuleEngine_PropertyChanged;

            ToggleSwitchToggled_Command = new MyICommand<ToggleSwitch>(ToggleSwitchToggled);

            LoadControls();
            GetEngineRules();
        }

        private void FakeRuleEngine_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine("FakeRuleEngine_PropertyChanged... fired, e.PropertyName: " + e.PropertyName);
            // vang as n Rule se Running status verander. Update die "lig" asook start/stop buttons
            throw new NotImplementedException();
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
            Rules = new List<OptionRules>
            {
                new OptionRules {ID = 1, RuleType= "ATM"},
                new OptionRules {ID = 2, RuleType= "HigherCalls"},
            };

            ListTradeAction = new List<BidOffer>
            {
                new BidOffer {ID = 1, Action= "Bid"},
                new BidOffer {ID = 2, Action= "Offer"}
            };

            RBTRules = new ObservableCollection<VMRule_Data>
            {
                new VMRule_Data
                {
                    RuleType = "ATM",
                    ID = "Mar21 WMAZ",
                    Qty = 1,
                    Vol = 33.75,
                    Wins = 500,
                    Xo = 0,
                    Action = "Bid",
                    Running = false
                },
                new VMRule_Data
                {
                    RuleType = "ATM",
                    ID = "JUN21 WMAZ",
                    Qty = 1,
                    Vol = 22.75,
                    Wins = 300,
                    Xo = 0,
                    Action = "Bid",
                    Running = false
                },
                new VMRule_Data
                {
                    RuleType = "HighCalls",
                    ID = "Mar21 WMAZ",
                    Qty = 1,
                    Vol = 22.75,
                    Wins = 0,
                    Xo = 0,
                    Action = "Bid",
                    Running = false
                },
                new VMRule_Data
                {
                    RuleType = "HighCalls",
                    ID = "JUN21 WMAZ",
                    Qty = 1,
                    Vol = 22.75,
                    Wins = 0,
                    Xo = 0,
                    Action = "Bid",
                    Running = false
                },
                new VMRule_Data
                {
                    RuleType = "HigherCalls",
                    ID = "JUN21 WMAZ",
                    Qty = 1,
                    Vol = 20.75,
                    Wins = 0,
                    Xo = 0,
                    Action = "Bid",
                    Running = false
                }
            };
        }

        private void GetEngineRules()
        {

        }
    }

    public class BidOffer
    {
        public int ID { get; set; }
        public string Action { get; set; }
    }
    public class OptionRules
    {
        public int ID { get; set; }
        public string RuleType { get; set; }
    }
    public class VMRule_Data
    {
        public string RuleType { get; set; }
        public string ID { get; set; }
        public double Qty { get; set; }
        public double Vol { get; set; }
        public double Wins { get; set; }
        public int Xo { get; set; }
        public string Action { get; set; }
        public bool Running { get; set; }
    }
}
