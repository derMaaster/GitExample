using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Core.Domain
{
    public class GetSecretString:ID_WriteString
    {
        public DebugStringClass GetName()
        {
            DebugStringClass debugStringClass = new DebugStringClass();
            debugStringClass.stringMessage = "My naam is Leeu";
            return debugStringClass;
        }

        public bool WriteString(DebugStringClass debugStringClass)
        {
            throw new NotImplementedException();
        }
    }
}
