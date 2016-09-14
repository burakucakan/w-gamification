using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Protocols;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;
using w2.Service.Gigya.GM.CustomObjects;
using w2.Ws.WS.Core;

namespace w2.Ws
{
    public class Query : BaseWs, IQuery
    {

        public UserPoints GetUserTotalPoints(QueryRequest request)
        {
            Compability(ref request);
            GetChallengeStatusResponse resp = _GetUserTotalPointsLogic(request);

            //Dönüş Objesi Oluşturulur
            UserPoints returnObj = new UserPoints();
            returnObj.SetDefaults(resp);

            //Error kontrolüne göre logic yazılır, istenen değerler set edilir
            if (!returnObj.HasErrors())
            {
                foreach (var item in resp.Achievements)
                    returnObj.PointsTotal += item.PointsTotal;
            }
            return returnObj;
        }
        public void GetUserTotalPoints()
        {
            PrintJson(GetUserTotalPoints(null));
        }

        public GetChallengeStatusResponse _GetUserTotalPointsLogic(QueryRequest request)
        {
            //Gigya'ya gönderilecek olan request objesi değerleri girilir
            GetChallengeStatus req = new GetChallengeStatus();
            req.Msisdn = request.Msisdn;
            req.Key = request.Key;
            GameMechanic gm = new GameMechanic();
            //Gigya'ya request objesi gönderilerek response alınır
            GetChallengeStatusResponse resp = gm.GetChallengeStatus(req);
            return resp;
        }


    }
}
    