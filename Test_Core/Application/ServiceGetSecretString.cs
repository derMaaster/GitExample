
using Test_Core.Domain;

namespace Test_Core.Application
{
    public class ServiceGetSecretString:IService_GetSecretString
    {
        public IDomain_GetSecretString I_GetSecretString { get; }
        public ServiceGetSecretString()
        {
            I_GetSecretString = new DomainGetSecretString();
        }

        public string GetString()
        {
            //DebugStringClass debugStringClass = new DebugStringClass();
            var debugStringClass = I_GetSecretString.GetString();
            return debugStringClass.stringMessage;
        }
    }
}
