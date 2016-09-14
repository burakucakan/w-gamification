using Gnc2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvSmsQuery
    {
        public int GetUserPoints(string Key, string Msisdn)
        {
            ServiceSmsQuery.SmsQueryRequest req = new ServiceSmsQuery.SmsQueryRequest();
            req.Msisdn = Msisdn;
            req.Key = Key;

            ServiceSmsQuery.SmsQueryClient qclient = new ServiceSmsQuery.SmsQueryClient();
            return qclient.GetUserTotalPoints(req).TotalPoints;
        }

    }
}
