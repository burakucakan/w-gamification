using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;
using w2.Service.Gigya.GM.CustomObjects;
using w2.Ws.WS.Core;

namespace w2.Ws
{
    public class Badge : BaseWs, IBadge
    {
        public BadgeListQueryRequest GetAll(BadgeListQueryReq request)
        {
            Compability(ref request);
            GetChallengeConfig conf = new GetChallengeConfig();
            conf.Key = request.Key;

            GameMechanic gm = new GameMechanic();

            GetChallengeConfigResponse resp = gm.ChallengeConfig(conf);

            BadgeListQueryRequest returnObj = new BadgeListQueryRequest();
            returnObj.SetDefaults(resp);

            if (!returnObj.HasErrors())
            {
                List<BadgeModel> aa = new List<BadgeModel>(); 
                foreach (var item in resp.Challenges)
                {
                    var badgeModel = new BadgeModel();
                    badgeModel.Id = item.ChallengeID;
                    badgeModel.Name = item.Name;
                    badgeModel.Description = item.Description;
                    badgeModel.ImageUrl = item.Levels[0].BadgeURL;
                    aa.Add(badgeModel);
                    
                }

                returnObj.Badges= aa;
            }

            return returnObj;
        }
        public void GetAll()
        {
            PrintJson(GetAll(null));
        }

        public BadgeListQueryRequest GetNRandom(BadgeListQueryReq request)
        {
            Compability(ref request);
            var g = GetAll(request);
            g.Badges = g.Badges.AsEnumerable().OrderBy(p => Guid.NewGuid()).Take(request.NTop).ToList();
            return g;
        }
        public void GetNRandom()
        {
            PrintJson(GetNRandom(null));
        }

        public BadgeUserListModel GetUserBadge(BadgeListQueryReq request)
        {
            Compability(ref request);
            GetChallengeStatus conf = new GetChallengeStatus();
            conf.Key = request.Key;
            conf.Msisdn = request.Msisdn;

            GameMechanic gm = new GameMechanic();

            GetChallengeStatusResponse resp = gm.GetChallengeStatus(conf);

            BadgeUserListModel returnObj = new BadgeUserListModel();
            returnObj.SetDefaults(resp);

            if (!returnObj.HasErrors())
            {

                List<UserBadgeModel> userbadgemod = new List<UserBadgeModel>();

                foreach (var item in resp.Achievements)
                {
                    var userbadgeModel = new UserBadgeModel();
                    userbadgeModel.ChallengeID = item.ChallengeID;
                    userbadgeModel.Level = item.Level;
                    userbadgeModel.Points7Days = item.Points7Days;
                    userbadgeModel.PointsTotal = item.PointsTotal;
                    userbadgeModel.Rank = item.Rank;
                    userbadgeModel.Rank7Days = item.Rank7Days;
                    userbadgeModel.BadgeURL = item.BadgeURL;

                    userbadgemod.Add(userbadgeModel);

                }

                returnObj.Badges = userbadgemod;
            }

            return returnObj;
        }
        public void GetUserBadge()
        {
            PrintJson(GetUserBadge(null));
        }
    }
}



