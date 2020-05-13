using System.Diagnostics;

namespace Test_Core.Domain
{
    public class Debug_WriteString : IWriteString
    {
        public bool WriteString(string s)
        {
            try
            {
                Debug.WriteLine("DebugWriteStringClass writing: " + s);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
