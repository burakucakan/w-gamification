using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wSrvBridge.Logger
{
    // Amacimiz loglanan verinin nereden geldigine dair
    // daha net bilgi sahibi olmak. Böylece log success ya da 
    // failure oldugunda, hangi katmana bakacagimizi daha iyi
    // biliriz.
    public enum LogLevel
    {
        Persistance,
        Connector,
        Library,
        Service,
        Resource
    }

    public enum LogType
    {
        Notification,
        Exception
    }

    public interface ILog
    {
        LogLevel Level { get; set; }
        LogType Type { get; set; }
        DateTime CreatedAt { get; set; }
        int ActivePlatform { get; set; }
        string Message { get; set; }
        string ExceptionType { get; set; }
        string Naming { get; set; }
        string Operation { get; set; }
        string ResponseData { get; set; }
        string Referrer { get; set; }
    }
}
