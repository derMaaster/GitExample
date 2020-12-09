using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Full_Arch_UWP_Autofac.Helpers;
using System.Collections.ObjectModel;
using Test_Core.Application;
using System.Diagnostics;
using Test_Core.Domain;

using Windows.UI.Xaml.Controls;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class FakeRulePage_ViewModel:NotificationBaseHelper
    {
        private readonly IFakeRule_Engine _fakeRuleEngine;

        public ObservableCollection<RBTRule_Data> RBTRules { get; set; } = new ObservableCollection<RBTRule_Data>();
        public List<TradeAction> ListTradeAction { get; set; } = new List<TradeAction>();



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
            ListTradeAction.Add(TradeAction.Bid);
            ListTradeAction.Add(TradeAction.Offer);
        }
        private void GetEngineRules()
        {
            var newATMRule = new RBTRule_Data()
            {
                RuleType = RuleType.ATM,
                MonthID = "Mar21 WMAZ",
                Qty = 1,
                Wins = 300,
                Vol = 33.75,
                Running = false
            };
            var newATMRuleTwo = new RBTRule_Data()
            {
                RuleType = RuleType.ATM,
                MonthID = "JUL 21 WMAZ",
                Qty = 1,
                Wins = 500,
                Vol = 26.5,
                Running = false
            };
            RBTRules.Add(newATMRule);
            RBTRules.Add(newATMRuleTwo);


            var newStrikeRule = new RBTRule_Data()
            {
                RuleType = RuleType.Strike,
                MonthID = "Mar21 WMAZ",
                Qty = 1,
                Xo = 3000,
                Vol = 33.75,
                BidOffer = Test_Core.Domain.TradeAction.Bid,
                Running = false
            };
            var newStrikeRuleTwo = new RBTRule_Data()
            {
                RuleType = RuleType.Strike,
                MonthID = "JUL 21 WMAZ",
                Qty = 1,
                Xo = 4100,
                Vol = 26.75,
                BidOffer = Test_Core.Domain.TradeAction.Offer,
                Running = false
            };
            RBTRules.Add(newStrikeRule);
            RBTRules.Add(newStrikeRuleTwo);
        }
    }
}
