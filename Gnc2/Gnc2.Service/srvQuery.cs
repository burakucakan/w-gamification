using Gnc2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvQuery
    {
        public ServiceQuery.UserPoints GetUserPoints(string Key, string Msisdn)
        {
            ServiceQuery.QueryRequest req = new ServiceQuery.QueryRequest();
            req.Msisdn = Msisdn;
            req.Key = Key;

            ServiceQuery.QueryClient qclient = new ServiceQuery.QueryClient();
            return qclient.GetUserTotalPoints(req);
        }

    }
}
