using System;

namespace wSrvConnector
{
    public interface IServiceConnector
    {
        string ConfigurationName { get; set; }
        void InitializeService();
    }
}
