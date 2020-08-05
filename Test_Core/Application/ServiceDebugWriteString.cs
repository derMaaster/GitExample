using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Helpers;

using Test_Core.Domain;

namespace Test_Core.Application
{
    public class ServiceDebugWriteString:NotificationBaseHelper,IService_DebugWriteString
    {
        private Boolean TestINPC_;         
        public Boolean TestINPC
        {
            get { return TestINPC_; }
            set { SetProperty(ref TestINPC_, value); }
        }


        public IDomain_WriteString DomainDebugWriteString { get; }
        public ServiceDebugWriteString(IDomain_WriteString debugWriting)
        {
            DomainDebugWriteString = debugWriting;

            // set status on startup as callable/not started: this pulls through to button text
            TestINPC = false;
        }

        public void WriteString(string stringMessage)
        {
            DebugStringClass debugStringClass = new DebugStringClass();
            debugStringClass.stringMessage = stringMessage;
            DomainDebugWriteString.WriteStringToDebug(debugStringClass);

            //just toggle between previous state:
            if (stringMessage == "Start indicated")
            {
                TestINPC = true;
            }
            if (stringMessage == "Stop indicated")
            {
                TestINPC = false;
            }
        }

        public bool GetStatusBool()
        {
            return TestINPC;
        }
    }
}
