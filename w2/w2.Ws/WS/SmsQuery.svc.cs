using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.DB;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;
using w2.Ws.WS.Core;

namespace w2.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SmsQuery" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SmsQuery.svc or SmsQuery.svc.cs at the Solution Explorer and start debugging.
    public class SmsQuery : BaseWs, ISmsQuery
    {
        public SmsQueryResponse GetUserTotalPoints(SmsQueryRequest request)
        {
            Compability(ref request);
            w2.Ws.Query q=new Query();

            QueryRequest queryRequest = new QueryRequest();
            queryRequest.Key = request.Key;
            queryRequest.Msisdn = request.Msisdn;
            GetChallengeStatusResponse response = q._GetUserTotalPointsLogic(queryRequest);

            SmsQueryResponse returnResponse = new SmsQueryResponse();
            returnResponse.SetDefaults(response);

            if (response.ErrorCode == (int)ResponseCodes.GigyaErrorCode.UnauthorizedUser)
            {
                returnResponse.TotalPoints = 0;
                return returnResponse;
            }
            else if (response.ErrorCode == (int)ResponseCodes.GigyaErrorCode.NoError)
            {
                if (!returnResponse.HasErrors())
                {
                    foreach (var item in response.Achievements)
                        returnResponse.TotalPoints += item.PointsTotal;
                }
            }

            VendorLogs log = new VendorLogs();
            log.AuthKey = request.Key;
            log.CallId = response.CallId;
            log.Msisdn = request.Msisdn;
            Log(log);

            return returnResponse;
        }
        public void GetUserTotalPoints()
        {
            PrintJson(GetUserTotalPoints(null));
        }

        public SmsQueryActionResponse GetActionPoints(SmsQueryActionRequest request)
        {
            Compability(ref request);
            GetActionConfig req = new GetActionConfig();
            GameMechanic gm = new GameMechanic();
            SmsQueryActionResponse returnResponse = new SmsQueryActionResponse();
            GetActionConfigResponse response;

            req.IncludeActions = request.ActionName;
            req.Key = request.Key;
            response = gm.ActionConfig(req);

            returnResponse.SetDefaults(response);
            if (response.Actions !=null && response.Actions.Count() > 0)
                returnResponse.ActionPoints = response.Actions[0].Points;
            else
                returnResponse.ActionPoints = 0;
            return returnResponse;
        }
        public void GetActionPoints()
        {
            PrintJson(GetActionPoints(null));
        }

    }
}
