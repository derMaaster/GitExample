using System.Diagnostics;

namespace Test_Core.Domain
{
    public class DebugWriteString : ID_WriteString
    {
        public bool WriteString(DebugStringClass debugStringClass)
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
