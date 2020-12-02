using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Helpers;

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
    }
}
