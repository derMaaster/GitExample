using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Core.Application
{
    public class TradeInstrumente
    {
        public string MonthID { get; set; }
        public string Outright { get; set; }
        public string OutrightCode { get; set; }
        public string Delta { get; set; }
        public string DeltaCode { get; set; }
        public string Future { get; set; }
        public string FutureCode { get; set; }
        public DateTime OptionExpiry { get; set; }

        public TradeInstrumente( string monthID, string outright, string outrightCode, string delta,string deltaCode,
            string future, string futureCode, DateTime optionExpiry)
        {
            MonthID = monthID;
            Outright = outright;
            OutrightCode = outrightCode;
            Delta = delta;
            DeltaCode = deltaCode;
            Future = future;
            FutureCode = futureCode;
            OptionExpiry = optionExpiry;
        }

    }
}
