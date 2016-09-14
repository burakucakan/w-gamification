using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.Service.Gigya.GM;
using w2.Ws.WS.Core;


namespace w2.Ws
{
    public class LeaderBoard : BaseWs, ILeaderBoard
    {
        public LeaderListModel TopN(LeaderListRequest request)
        {
            Compability(ref request);
            GetTopUsers tuser = new GetTopUsers();
            tuser.Key = request.Key;
            tuser.TotalCount = request.TotalCount;
            GameMechanic gm = new GameMechanic();

            GetTopUsersResponse resp = gm.GetTopUsers(tuser);

            LeaderListModel returnObj = new LeaderListModel();
           
            returnObj.SetDefaults(resp);

            if (!returnObj.HasErrors())
            {
                foreach (var item in resp.UserObjList)
                {
                    
                        LeaderModel lmd = new LeaderModel();
                        lmd.Id = item.Msisdn;
                        lmd.Name = item.Name;
                        lmd.Picture = item.PhotoURL;
                        lmd.Point = item.Rank;
                        returnObj.Leaders.Add(lmd);
                }
            }

            return returnObj;
            
        }
        public void TopN()
        {
            PrintJson(TopN(null));
        }

        public LeaderListModel GetUserRank(UserRankRequest request)
        {
            Compability(ref request);
            GetTopUsers tuser = new GetTopUsers();
            tuser.Key = request.Key;
            tuser.Msisdn = request.Msisdn;
            tuser.IncludeSelf = true;
            GameMechanic gm = new GameMechanic();

            GetTopUsersResponse resp = gm.GetTopUsers(tuser);

            LeaderListModel returnObj = new LeaderListModel();

            returnObj.SetDefaults(resp);

            if (!returnObj.HasErrors())
            {
                foreach (var item in resp.UserObjList)
                {
                    LeaderModel lmd = new LeaderModel();
                    lmd.Id = item.Msisdn;
                    lmd.Name = item.Name;
                    lmd.Picture = item.PhotoURL;
                    lmd.Point = item.Rank;
                    returnObj.Leaders.Add(lmd);
                }
            }
            // geri ne dönecek?
            return returnObj;

        }
        public void GetUserRank()
        {
            PrintJson(GetUserRank(null));
        }
    }
}
