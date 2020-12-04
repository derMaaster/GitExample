using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Helpers;
using System.Threading.Tasks;

namespace Test_Core.Domain
{
    public class RBTATM:RuleBase
    {
        

        public RBTATM(string ruleID)
        {
            RuleRunning = false;
            ExitRule = false;
            ID = ruleID;
        }


    }
}
