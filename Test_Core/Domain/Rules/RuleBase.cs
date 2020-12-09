using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Helpers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Test_Core.Domain
{
    public abstract class RuleBase:NotificationBaseHelper
    {
        private bool _ruleRunning;
        private bool _exitRule;
        private string _infoINPC;
        private readonly RuleType _ruleType;
        private readonly TradeAction _tradeAction;

        public string MonthID;
        public string RuleID;
        public double Qty;        
        public double Vol;
        
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

        public RuleBase(
            string monthID,
            string ruleID,            
            double qty,
            double vol,
            RuleType ruleType,
            int xo=0, double wins=0,
            TradeAction tradeAction=TradeAction.Bid)
        {
            RunRuleChecks(ruleID, monthID,ruleType,vol, xo,wins);

            Debug.WriteLine("gaan voort met RuleBase instantiation...");
            RuleRunning = false;
            ExitRule = false;
            InfoINPC = "";

            MonthID = monthID;
            RuleID = ruleID;
            Qty = qty;
            Vol = vol;
            _ruleType = ruleType;
            _tradeAction = tradeAction;

            Xo = xo;
            Wins = wins;            
        }

        private void RunRuleChecks(string ruleID, string monthID, RuleType ruleType, double vol, int xo = 0, double wins = 0)
        {
            bool result = false;
            switch (_ruleType)
            {
                case RuleType.ATM:
                    result = ATMCheck();
                    break;
                case RuleType.Strike:
                    result = StrikeCheck();
                    break;
            }

            if (!result)
            {
                InfoINPC = "Rule input failed checks: Rule: " + monthID + "; " + ruleType.ToString() + "; " + vol + "; " + xo + "; " + wins;
                Debug.WriteLine("rulechecks failed");
                return;
            }
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


        // Rule Checks:
        private bool ATMCheck()
        {
            bool result = true;

            if (Qty <= 0)
            {
                result = false;
            }

            return result;
        }
        private bool StrikeCheck()
        {
            bool result = true;

            if (Xo == 0)
            {
                result = false;
            }

            return result;
        }


        // Rule variations:
        public async Task RunATMRule()
        {
            while (!ExitRule)
            {
                // do work in rule to get somewhere in life:
                await Task.Delay(100);
            }
            InfoINPC = "End of RunATMRule(): " + MonthID;
        }
        public async Task RunStrikeRule()
        {
            while (!ExitRule)
            {
                // do work in rule to get somewhere in life:
                await Task.Delay(100);
            }
            InfoINPC = "End of RunStrikeRule(): " + MonthID;
        }

    }
}
