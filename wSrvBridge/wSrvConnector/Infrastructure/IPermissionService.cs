using System;
using wSrvConnector.ServiceModels;

namespace wSrvConnector
{
    public interface IPermissionService : IServiceConnector
    {
        PermissionServiceResult GetServicePermission(string msisdn);
        PermissionServiceResult WriteServicePermission(string msisdn, PermissionServiceOptout optout);
    }
}
