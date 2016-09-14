using System;
using wSrvBridge.Lib;
using wSrvConnector;
using wSrvConnector.ServiceModels;
using wSrvBridge.Logger;

namespace wSrvLocatorLibrary
{
    public class PermissionQueryService : IPermissionQueryService
    {

        public PermissionQueryResult WriteServicePermission(string msisdn, Permission permission)
        {
            PermissionQueryResult queryResult;
            try
            {
                using (PermissionService serviceConnector = ServiceFactory<PermissionService>.GetServiceClient(WebServiceNaming.wsVeriIslemeIzni))
                {
                    serviceConnector.InitializeService();

                    PermissionServiceOptout optout = (PermissionServiceOptout)((int)permission);
                    PermissionServiceResult serviceResult = serviceConnector.WriteServicePermission(msisdn, optout);
                    queryResult = new PermissionQueryResult
                    {
                        Success = serviceResult.Success,
                        Message = serviceResult.Message
                    };

                    var log = Logger.CreateNotificationLog(LogLevel.Library, "WriteServicePermission call successfull");
                    log.Naming = WebServiceNaming.wsVeriIslemeIzni.ToString();
                    log.Operation = "WriteServicePermission";
                    Logger.Save(log);
                }
            }
            catch (Exception exc)
            {
                queryResult = new PermissionQueryResult
                {
                    Success = false,
                    Message = exc.Message,
                    Permission = null
                };

                var log = Logger.CreateErrorLog(LogLevel.Library, exc);
                log.Naming = WebServiceNaming.wsVeriIslemeIzni.ToString();
                log.Operation = "WriteServicePermission";
                
                Logger.Save(log);
            }

            return queryResult;
        }

        public PermissionQueryResult GetServicePermission(string msisdn)
        {
            PermissionQueryResult queryResult;
            try
            {
                using (PermissionService serviceConnector = ServiceFactory<PermissionService>.GetServiceClient(WebServiceNaming.wsVeriIslemeIzni))
                {
                    serviceConnector.InitializeService();
                    
                    PermissionServiceResult serviceResult = serviceConnector.GetServicePermission(msisdn);
                    queryResult = new PermissionQueryResult
                    {
                        Success = serviceResult.Success,
                        Permission = serviceResult.Permission.ToString(),
                        ModifyDate = serviceResult.ModifyDate,
                        ModifyUser = serviceResult.ModifyUser,
                        Message = serviceResult.Message
                    };

                    var log = Logger.CreateNotificationLog(LogLevel.Library, "GetServicePermission call successfull");
                    log.Naming = WebServiceNaming.wsVeriIslemeIzni.ToString();
                    log.Operation = "GetServicePermission";
                    Logger.Save(log);
                }
            }
            catch (Exception exc)
            {
                queryResult = new PermissionQueryResult
                {
                    Success = false,
                    Message = exc.Message,
                    Permission = null,
                    ModifyUser = null,
                    ModifyDate = null
                };

                var log = Logger.CreateErrorLog(LogLevel.Library, exc);
                log.Naming = WebServiceNaming.wsVeriIslemeIzni.ToString();
                log.Operation = "GetServicePermission";
                Logger.Save(log);
            }

            return queryResult;
        }
    }
}
