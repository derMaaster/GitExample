using System;
using System.Collections.Generic;
using System.Text;

using Test_Core.UseCase;

namespace Test_Core.DataAdaptorLayer
{
    public class DebugWriteString:IUC_DebugWriting
    {
        public IUC_DebugWriting DomainDebugWriting { get; }
        public DebugWriteString(IUC_DebugWriting debugWriting)
        {
            DomainDebugWriting = debugWriting;
        }


        
    }
}
