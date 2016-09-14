using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Service
{
    public class srvGameMechanics
    {
        public Service.ServiceGameMechanics.GetChallengeStatusResponse GetChallengeConfig(string Key, string Msisdn)
        {  
            ServiceGameMechanics.GameMechanicsClient srv = new ServiceGameMechanics.GameMechanicsClient();
            ServiceGameMechanics.GetChallengeStatus req = new ServiceGameMechanics.GetChallengeStatus();
            req.Key = Key;
            req.Msisdn = Msisdn;

            return srv.GetChallengeStatus(req);
          
        }


        public Service.ServiceGameMechanics.RedeemPointsResponse RedeemPoint(string Key, string Msisdn)
        {
            ServiceGameMechanics.GameMechanicsClient srv = new ServiceGameMechanics.GameMechanicsClient();
            ServiceGameMechanics.RedeemPoints ent = new ServiceGameMechanics.RedeemPoints();
            ent.Key = Key;
            ent.Msisdn = Msisdn;
            return srv.RedeemPoints(ent);
        }
      
    }
}
