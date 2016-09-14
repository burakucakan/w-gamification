using System;
using wSrvConnector;
using wSrvBridge.Lib;
using wSrvBridge.Logger;
using wSrvConnector.ServiceModels;

namespace wSrvLocatorLibrary
{
    public class SmsService : ISmsService
    {
        public SmsServiceResult SendSms(string AppId, string Msisdn, string SmsText)
        {
            SmsServiceResult result;
            try
            {
                using (wSrvConnector.SmsService serviceConnector = ServiceFactory<wSrvConnector.SmsService>.GetServiceClient(WebServiceNaming.wsPennaSmsGonder))
                {
                    serviceConnector.InitializeService();
                    wSrvConnector.ServiceModels.SmsServiceResult serviceResult = serviceConnector.SendSms(AppId, Msisdn, SmsText);
                    
                    result = new SmsServiceResult
                    {
                        Success = serviceResult.Success,
                        Message = serviceResult.Message
                    };

                    var log = Logger.CreateNotificationLog(LogLevel.Library, "SendSms call successful");
                    log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                    log.Operation = "SendSms";
                    log.ResponseData = serviceResult.Message;

                    Logger.Save(log);
                }
            }
            catch (Exception exc)
            {
                result = new SmsServiceResult
                {
                    Success = false,
                    Message = exc.Message
                };

                var log = Logger.CreateErrorLog(LogLevel.Library, exc);
                log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                log.Operation = "SendSms";

                Logger.Save(log);
            }

            return result;
        }

        public SmsServiceResult NewTicket(string AppId, string Msisdn)
        {
            SmsServiceResult result;
            try
            {
                using (wSrvConnector.SmsService serviceConnector = ServiceFactory<wSrvConnector.SmsService>.GetServiceClient(WebServiceNaming.wsPennaSmsGonder))
                {
                    serviceConnector.InitializeService();
                    wSrvConnector.ServiceModels.SmsServiceResult serviceResult = serviceConnector.NewTicket(AppId, Msisdn);

                    result = new SmsServiceResult
                    {
                        Success = serviceResult.Success,
                        Message = serviceResult.Message
                    };

                    var log = Logger.CreateNotificationLog(LogLevel.Library, "NewTicket call successful");
                    log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                    log.Operation = "NewTicket";
                    log.ResponseData = serviceResult.Message;

                    Logger.Save(log);
                }
            }
            catch (Exception exc)
            {
                result = new SmsServiceResult
                {
                    Success = false,
                    Message = exc.Message
                };

                var log = Logger.CreateErrorLog(LogLevel.Library, exc);
                log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                log.Operation = "NewTicket";

                Logger.Save(log);
            }

            return result;
        }
    }
}
