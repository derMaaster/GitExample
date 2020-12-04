using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Helpers;
using System.Threading.Tasks;

namespace Test_Core.Domain
{
    public abstract class RuleBase:NotificationBaseHelper
    {
        private bool _ruleRunning;
        private bool _exitRule;
        private string _infoINPC;       

        public string ID;
        public double Qty;        
        public double Vol;
        private readonly RuleType _ruleType;
        private readonly TradeAction _tradeAction;

        public bool RuleRunning
        {
            get { return _ruleRunning; }
            set { SetProperty(ref _ruleRunning, value); }
        }
        public bool ExitRule
        {
            get { return _exitRule; }
            set { SetProperty(ref _exitRule, value); }
        }
        public string InfoINPC
        {
            get { return _infoINPC; }
            set { SetProperty(ref _infoINPC, value); }
        }

        //optional parameters
        public int Xo;
        public double Wins;

        public RuleBase(string ruleID, RuleType ruleType, int xo=0, double wins=0, TradeAction tradeAction=TradeAction.Bid)
        {
            RunRuleChecks(ruleID,ruleType,xo,wins);

            RuleRunning = false;
            ExitRule = false;
            ID = ruleID;
            _ruleType = ruleType;
            _tradeAction = tradeAction;

            Xo = xo;
            Wins = wins;            
        }

        private void RunRuleChecks(string ruleID, RuleType ruleType, int xo = 0, double wins = 0)
        {

        }
        public void RunRule()
        {
            switch (_ruleType)
            {
                case RuleType.ATM:
                    _ = RunATMRule();
                    break;
                case RuleType.Strike:
                    _ = RunStrikeRule();
                    break;
            }
        }


        public async Task RunATMRule()
        {
            while (!ExitRule)
            {
                // do work in rule to get somewhere in life:
                await Task.Delay(100);
            }
            InfoINPC = "End of RunATMRule(): " + ID;
        }
        public async Task RunStrikeRule()
        {
            while (!ExitRule)
            {
                // do work in rule to get somewhere in life:
                await Task.Delay(100);
            }

            InfoINPC = "End of RunStrikeRule(): " + ID;
        }

    }
}
