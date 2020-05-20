using System.Diagnostics;

namespace Test_Core.Domain
{
    public class DomainDebugWriteString : IDomain_WriteString
    {
        public bool WriteStringToDebug(DebugStringClass debugStringClass)
        {
            try
            {
                Debug.WriteLine("DebugWriteStringClass writing: " + debugStringClass.stringMessage);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
