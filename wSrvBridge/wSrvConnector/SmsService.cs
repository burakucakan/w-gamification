using System;
using System.ServiceModel;
using wSrvBridge.Lib;
using wSrvBridge.Logger;
using wSrvConnector.PennaSmsService;
using wSrvConnector.ServiceModels;

namespace wSrvConnector
{
    public class SmsService : ServiceBase, ISmsService, IDisposable
    {

        private EventsSoapClient _serviceClient;

        public override void InitializeService()
        {
            if (String.IsNullOrWhiteSpace(ConfigurationName))
            {
                _serviceClient = new EventsSoapClient();
            }
            else
            {
                var log = Logger.CreateNotificationLog(LogLevel.Connector, "SmsService Initialized with custom configuration: " + ConfigurationName);
                log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                log.Operation = "InitializeService";
                Logger.Save(log);

                _serviceClient = new EventsSoapClient(ConfigurationName);
            }
        }

        public SmsServiceResult SendSms(string AppId, string Msisdn, string SmsText)
        {
            try
            {
                string serviceResult = _serviceClient.sendSms(ServiceConfigurationManager.PennaUsername, ServiceConfigurationManager.PennaPassword, AppId, Msisdn, SmsText, "", "");
                return new SmsServiceResult
                {
                    Success = true,
                    Message = serviceResult
                };
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Connector, exc);
                log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                log.Operation = "SendSms";

                Logger.Save(log);

                return new SmsServiceResult
                {
                    Success = false,
                    Message = exc.Message
                };
            }
        }

        public SmsServiceResult NewTicket(string AppId, string Msisdn)
        {
            try
            {
                string serviceResult = _serviceClient.insertNewTicket(ServiceConfigurationManager.PennaUsername, ServiceConfigurationManager.PennaPassword, AppId, Msisdn, "", "", "");
                return new SmsServiceResult
                {
                    Success = true,
                    Message = serviceResult
                };
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Connector, exc);
                log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                log.Operation = "NewTicket";

                Logger.Save(log);

                return new SmsServiceResult
                {
                    Success = false,
                    Message = exc.Message
                };
            }
        }

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                bool success = false;
                if (_serviceClient != null)
                {
                    try
                    {
                        if (_serviceClient.State != CommunicationState.Faulted)
                        {
                            _serviceClient.Close();
                            success = true;

                            var log = Logger.CreateNotificationLog(LogLevel.Connector, "Service Client disposed successfully");
                            log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();

                            Logger.Save(log);
                        }
                    }
                    finally
                    {
                        if (!success)
                        {
                            var log = Logger.CreateNotificationLog(LogLevel.Connector, "Service Client has recovered from CommunicationState.Faulted state");
                            log.Naming = WebServiceNaming.wsPennaSmsGonder.ToString();
                            Logger.Save(log);

                            _serviceClient.Abort();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
