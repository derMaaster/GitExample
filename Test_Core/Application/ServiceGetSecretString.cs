
using Test_Core.Domain;

namespace Test_Core.ServiceLayer
{
    public class ServiceGetSecretString:IService_GetSecretString
    {
        public IDomain_GetSecretString I_GetSecretString { get; }
        public ServiceGetSecretString(IDomain_GetSecretString i_GetSecretString)
        {
            I_GetSecretString = i_GetSecretString;
        }

        public string GetString()
        {
            //DebugStringClass debugStringClass = new DebugStringClass();
            var debugStringClass = I_GetSecretString.GetString();
            return debugStringClass.stringMessage;
        }
    }
}
