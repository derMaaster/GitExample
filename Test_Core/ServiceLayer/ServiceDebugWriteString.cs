using System;
using System.Collections.Generic;
using System.Text;

using Test_Core.Domain;

namespace Test_Core.ServiceLayer
{
    public class ServiceDebugWriteString:IService_DebugWriteString
    {
        public IDomain_WriteString DomainDebugWriteString { get; }
        public ServiceDebugWriteString(IDomain_WriteString debugWriting)
        {
            DomainDebugWriteString = debugWriting;
        }

        public void WriteString(string stringMessage)
        {
            DebugStringClass debugStringClass = new DebugStringClass();
            debugStringClass.stringMessage = stringMessage;
            DomainDebugWriteString.WriteStringToDebug(debugStringClass);
        }

    }
}
