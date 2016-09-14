using System;
using System.ServiceModel;
using wSrvConnector.ServiceModels;
using wSrvConnector.PermissionServicesStb2;
using wSrvBridge.Logger;
using wSrvBridge.Lib;

namespace wSrvConnector
{
    public class PermissionService : ServiceBase, IPermissionService, IDisposable
    {
        private PermissionWebServicePortTypeClient _serviceClient;
        private readonly int _serviceId;
        private readonly int _serviceSourceId;

        public PermissionService()
        {
            _serviceId = ServiceConfigurationManager.PermissionServiceId;
            _serviceSourceId = ServiceConfigurationManager.PermissionServiceSourceId;
        }

        public override void InitializeService()
        {
            if (String.IsNullOrWhiteSpace(ConfigurationName))
            {
                _serviceClient = new PermissionWebServicePortTypeClient();
            }
            else
            {
                var log = Logger.CreateNotificationLog(LogLevel.Connector, "PermissionService Initialized with custom configuration: " + ConfigurationName);
                log.Naming = WebServiceNaming.wsVeriIslemeIzni.ToString();
                log.Operation = "InitializeService";
                Logger.Save(log);

                _serviceClient = new PermissionWebServicePortTypeClient(ConfigurationName);
            }
        }

        public PermissionServiceResult GetServicePermission(string msisdn)
        {
            PermissionServiceResult returnResult;
            try
            {
                PermQueryExtResult serviceResult = _serviceClient.getServicePerm(msisdn, _serviceId);
                returnResult = new PermissionServiceResult
                {
                    Success = serviceResult.success,
                    Message = serviceResult.message,
                    ModifyDate = serviceResult.modifyDate,
                    ModifyUser = serviceResult.modifyUser,
                    Permission = (PermissionServiceOptout)serviceResult.coptout
                };
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Connector, exc);
                log.Naming = WebServiceNaming.wsVeriIslemeIzni.ToString();
                log.Operation = "GetServicePermission";
                Logger.Save(log);

                returnResult = new PermissionServiceResult
                {
                    Permission = PermissionServiceOptout.ServiceExceptionOccured,
                    Success = false,
                    Message = exc.Message
                };
            }

            return returnResult;
        }

        public PermissionServiceResult WriteServicePermission(string msisdn, PermissionServiceOptout optout)
        {
            PermissionServiceResult returnResult;
            try
            {
                PermWriteResult serviceResult = _serviceClient.writeServicePerm(msisdn, _serviceId, (int)optout, _serviceSourceId, msisdn);
                returnResult = new PermissionServiceResult
                {
                    Success = serviceResult.success,
                    Message = serviceResult.message
                };
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Connector, exc);
                log.Naming = WebServiceNaming.wsVeriIslemeIzni.ToString();
                log.Operation = "WriteServicePermission";
                Logger.Save(log);

                returnResult = new PermissionServiceResult
                {
                    Permission = PermissionServiceOptout.ServiceExceptionOccured,
                    Success = false,
                    Message = exc.Message
                };
            }

            return returnResult;
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

                            Logger.Save(Logger.CreateNotificationLog(LogLevel.Connector, "Service Client disposed successfully"));
                        }
                    }
                    finally
                    {
                        if (!success)
                        {
                            var log = Logger.CreateNotificationLog(LogLevel.Connector, "Service Client has recovered from CommunicationState.Faulted state");
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
