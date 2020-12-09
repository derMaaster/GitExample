using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Core.Domain;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class RBTRule_Data
    {
        public RuleType RuleType { get; set; }
        public string MonthID { get; set; }
        public double Qty { get; set; }
        public double Vol { get; set; }
        public double Wins { get; set; }
        public int Xo { get; set; }        
        public TradeAction BidOffer { get; set; }

        public bool Running { get; set; }
    }
}
