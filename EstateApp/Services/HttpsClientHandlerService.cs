using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateApp.Services
{
    public class HttpsClientHandlerService
    {
        public HttpMessageHandler GetPlatformMessageHandler()
        {
            var handler = new Xamarin.Android.Net.AndroidMessageHandler();
            
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert != null && cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;

            throw new PlatformNotSupportedException("Only Android and iOS supported.");
        }
    }
}
