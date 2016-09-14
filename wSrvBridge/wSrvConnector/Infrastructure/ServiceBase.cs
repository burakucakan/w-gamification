using System;

namespace wSrvConnector
{
    public abstract class ServiceBase : IServiceConnector
    {
        public string ConfigurationName { get; set; }
        public abstract void InitializeService();
    }
}
