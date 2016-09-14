using System;
using System.Linq;
using wSrvBridge.DB;
using wSrvBridge.Lib;
using wSrvBridge.Logger;

namespace wSrvConnector
{
    public class ServiceFactory<T> where T : class, IServiceConnector, new()
    {
        public static T GetServiceClient(WebServiceNaming naming)
        {
            string configurationName;
            try
            {
                using (var context = new srvBridgeDbContainer(ServiceConfigurationManager.ActiveDbConnection))
                {
                    //Verilen naminge uygun, aktif platform için web.config endpoint nameini aliyoruz.
                    string wsNaming = naming.ToString();
                    WebService webServiceInfo = context.WebServices.Where(f => f.Naming == wsNaming && f.PlatformType == (int)ServiceConfigurationManager.ActivePlatform).SingleOrDefault();

                    if (webServiceInfo == null)
                    {
                        //Buraya istenilirse bir NotificationLog atilabilir. Ancak zaten exception handle edilecegi icin gerek yok.
                        throw new NullReferenceException("ServiceFactory::GetServiceClient");
                    }

                    configurationName = webServiceInfo.ConfigName;
                }

                T serviceClient = new T();
                serviceClient.ConfigurationName = configurationName;
                return serviceClient;
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Connector, exc);
                Logger.Save(log);

                return null;
            }
        }
    }
}
