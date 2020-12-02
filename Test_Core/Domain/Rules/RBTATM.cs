using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Helpers;
using System.Threading.Tasks;

namespace Test_Core.Domain
{
    public class RBTATM:RuleBase
    {
        public double Wins;

        public RBTATM(string ruleID)
        {
            RuleRunning = false;
            ExitRule = false;
            ID = ruleID;
        }

        public async Task RunFakeRule()
        {
            while (!ExitRule)
            {
                // do work in rule to get somewhere in life:
                await Task.Delay(100);
            }
            InfoINPC = "End of RunFakeRule(): " + ID;
        }
    }
}
