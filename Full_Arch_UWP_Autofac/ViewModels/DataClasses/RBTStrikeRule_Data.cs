using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Core.Domain;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class RBTStrikeRule_Data
    {
        public string MonthID { get; set; }
        public double Qty { get; set; }
        public double Xo { get; set; }
        public double Vol { get; set; }
        public TradeAction BidOffer { get; set; }
        public bool Running { get; set; }
        public bool Start { get; set; }
        public bool Stop { get; set; }
    }
}
