using System;

namespace wSrvBridge.Logger
{
    public class Log : ILog
    {
        public LogLevel Level { get; set; }
        public LogType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ActivePlatform { get; set; }
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string Naming { get; set; }
        public string Operation { get; set; }
        public string ResponseData { get; set; }
        public string Referrer { get; set; }
    }
}
