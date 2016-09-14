using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wSrvBridge.Lib;
using wSrvBridge.DB;

namespace wSrvBridge.Logger
{
    public sealed class Logger
    {
        public static ILog CreateNotificationLog(LogLevel level, string message)
        {
            return new Log
            {
                Type = LogType.Notification,
                Level = level,
                CreatedAt = DateTime.Now,
                ActivePlatform = (int)ServiceConfigurationManager.ActivePlatform,
                Message = message,
                ExceptionType = null,
                Naming = "",
                Operation = "",
                Referrer = "",
                ResponseData = ""
            };
        }

        public static ILog CreateErrorLog(LogLevel level, Exception exception)
        {
            return new Log
            {
                Type = LogType.Exception,
                Level = level,
                CreatedAt = DateTime.Now,
                ActivePlatform = (int)ServiceConfigurationManager.ActivePlatform,
                Message = exception.Message,
                ExceptionType = exception.GetType().Name,
                Naming = "",
                Operation = "",
                Referrer = "",
                ResponseData = ""
            };
        }

        public static void Save(ILog logData)
        {
            try
            {
                using (var context = new srvBridgeDbContainer(ServiceConfigurationManager.ActiveDbConnection))
                {
                    var serviceLog = new ServiceLog();
                    serviceLog.ActivePlatform = logData.ActivePlatform;
                    serviceLog.CreatedAt = logData.CreatedAt;
                    serviceLog.LogLevel = logData.Level.ToString();
                    serviceLog.Type = logData.Type.ToString();
                    serviceLog.Message = logData.Message;
                    serviceLog.ExceptionType = logData.ExceptionType;
                    serviceLog.Naming = logData.Naming;
                    serviceLog.Operation = logData.Operation;
                    serviceLog.ResponseData = logData.ResponseData;
                    serviceLog.Referrer = logData.Referrer;

                    context.ServiceLogs.Add(serviceLog);
                    context.SaveChanges();
                }
            }
            catch (Exception) { }
        }
    }
}
