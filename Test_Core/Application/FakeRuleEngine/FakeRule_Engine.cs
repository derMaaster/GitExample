using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Domain;
using Test_Core.Helpers;

namespace Test_Core.Application
{
    public class FakeRule_Engine:NotificationBaseHelper,IFakeRule_Engine
    {
        private RBTATM _rbtATMOne;
        private RBTATM _rbtATMTwo;
        private RBTStrike _rbtStrikeOne;
        private RBTStrike _rbtStrikeTwo;

        public RBTATM RBTATMOne 
        {
            get { return _rbtATMOne; }
            set { SetProperty(ref _rbtATMOne, value); }
        }
        public RBTATM RBTATMTwo
        {
            get { return _rbtATMTwo; }
            set { SetProperty(ref _rbtATMTwo, value); }
        }
        public RBTStrike RBTStrikeOne
        {
            get { return _rbtStrikeOne; }
            set { SetProperty(ref _rbtStrikeOne, value); }
        }
        public RBTStrike RBTStrikeTwo
        {
            get { return _rbtStrikeTwo; }
            set { SetProperty(ref _rbtStrikeTwo, value); }
        }

        Dictionary<string, RBTATM> ATMRules = new Dictionary<string, RBTATM>();
        Dictionary<string, RBTStrike> StrikeRules = new Dictionary<string, RBTStrike>();

        public FakeRule_Engine()
        {
            LoadRules();
        }
        private void LoadRules()
        {
            ATMRules.Add("ATMOne", RBTATMOne);
            ATMRules.Add("ATMTwo", RBTATMTwo);

            StrikeRules.Add("StrikeOne", RBTStrikeOne);
            StrikeRules.Add("StrikeTwo", RBTStrikeTwo);
        }

        public void StartRule(string ruleID)
        {
            //kry die Rule uit dictionary, en hardloop
        }
        public void StopRule(string ruleID)
        {
            //kry die Rule uit dictionary, en stop
        }


    }
}
