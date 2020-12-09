using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Domain;
using Test_Core.Helpers;

namespace Test_Core.Application
{
    public class FakeRule_Engine:NotificationBaseHelper,IFakeRule_Engine
    {
        private RuleBase _rbtATMOne;
        private RuleBase _rbtATMTwo;
        private RuleBase _rbtStrikeOne;
        private RuleBase _rbtStrikeTwo;

        public RuleBase RBTATMOne 
        {
            get { return _rbtATMOne; }
            set { SetProperty(ref _rbtATMOne, value); }
        }
        public RuleBase RBTATMTwo
        {
            get { return _rbtATMTwo; }
            set { SetProperty(ref _rbtATMTwo, value); }
        }
        public RuleBase RBTStrikeOne
        {
            get { return _rbtStrikeOne; }
            set { SetProperty(ref _rbtStrikeOne, value); }
        }
        public RuleBase RBTStrikeTwo
        {
            get { return _rbtStrikeTwo; }
            set { SetProperty(ref _rbtStrikeTwo, value); }
        }

        Dictionary<string, RuleBase> Rules = new Dictionary<string, RuleBase>();



        public FakeRule_Engine()
        {
            LoadRules();
        }
        private void LoadRules()
        {
            Rules.Add("ATMOne", RBTATMOne);
            Rules.Add("ATMTwo", RBTATMTwo);
            Rules.Add("StrikeOne", RBTStrikeOne);
            Rules.Add("StrikeTwo", RBTStrikeTwo);
        }

        public void StartRule(string ruleID)
        {
            //kry die Rule uit dictionary, INSTANTIATE elke keer, en hardloop
        }
        public void StopRule(string ruleID)
        {
            //kry die Rule uit dictionary, en stop
        }


    }
}
