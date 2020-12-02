using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Full_Arch_UWP_Autofac.Helpers;
using System.Collections.ObjectModel;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class FakeRulePage_ViewModel:NotificationBaseHelper
    {
        public ObservableCollection<RBTATMRules_Data> RBTATMRules { get; set; } = new ObservableCollection<RBTATMRules_Data>();
        public ObservableCollection<RBTStrikeRule_Data> RBTStrikeRules { get; set; } = new ObservableCollection<RBTStrikeRule_Data>();

        public FakeRulePage_ViewModel()
        {
            LoadRules();
        }
        private void LoadRules()
        {
            var newATMRule = new RBTATMRules_Data()
            {
                MonthID = "Mar21 WMAZ",
                Qty = 1,
                Wins = 300,
                Vol = 33.75,
                Running = false,
                Start = false,
                Stop = false
            };
            var newATMRuleTwo = new RBTATMRules_Data()
            {
                MonthID = "JUL 21 WMAZ",
                Qty = 1,
                Wins = 500,
                Vol = 26.5,
                Running = false,
                Start = false,
                Stop = false
            };
            RBTATMRules.Add(newATMRule);
            RBTATMRules.Add(newATMRuleTwo);


            var newStrikeRule = new RBTStrikeRule_Data()
            {
                MonthID = "Mar21 WMAZ",
                Qty = 1,
                Xo = 300,
                Vol = 33.75,
                BidOffer = Test_Core.Domain.TradeAction.Bid,
                Running = false,
                Start = false,
                Stop = false
            };
            var newStrikeRuleTwo = new RBTStrikeRule_Data()
            {
                MonthID = "JUL 21 WMAZ",
                Qty = 1,
                Xo = 400,
                Vol = 26.75,
                BidOffer = Test_Core.Domain.TradeAction.Offer,
                Running = false,
                Start = false,
                Stop = false
            };
            RBTStrikeRules.Add(newStrikeRule);
            RBTStrikeRules.Add(newStrikeRuleTwo);
        }
    }
}
