using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wSrvBridge.Lib
{
    public enum PlatformType
    {
        Development = 1,
        Stable,
        Prp,
        Production
    }

    public enum ConfigurationKeys
    {
        Platform,
        ActiveDbConnection,
        PermissionServiceId,
        PermissionServiceSourceId,
        PennaUsername,
        PennaPassword,
        PushInterval
    }

    public enum WebServiceNaming
    {
        wsVeriIslemeIzni,
        wsPennaSmsGonder,
        wsWindowsPushService,
        wsClubMembershipSearch
    }
}
