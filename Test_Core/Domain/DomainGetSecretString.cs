using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Core.Domain
{
    public class DomainGetSecretString:IDomain_GetSecretString
    {
        public DebugStringClass GetString()
        {
            DebugStringClass debugStringClass = new DebugStringClass();
            debugStringClass.stringMessage = "My naam is Leeu  aaaaaaaaaaaah!!!!!";
            return debugStringClass;
        }
    }
}
