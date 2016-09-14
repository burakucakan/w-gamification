using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvBadge
    {

        public ServiceBadge.BadgeUserListModel GetUserBadgeModel(string Key, string Msisdn)
        {
            ServiceBadge.BadgeListQueryReq req = new ServiceBadge.BadgeListQueryReq();
            req.Msisdn = Msisdn;
            req.Key = Key;

            ServiceBadge.BadgeClient srv = new ServiceBadge.BadgeClient();
            return srv.GetUserBadge(req);
            
        }

        public ServiceBadge.BadgeListQueryRequest GetBadgeModel(string Key)
        {
            ServiceBadge.BadgeListQueryReq req = new ServiceBadge.BadgeListQueryReq();
           
            req.Key = Key;
    
            ServiceBadge.BadgeClient srv = new ServiceBadge.BadgeClient();
            return srv.GetAll(req);
        }
    }
}
