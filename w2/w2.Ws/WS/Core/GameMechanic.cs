using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;

namespace w2.Ws.WS.Core
{
    public class GameMechanic
    {
        public GetTopUsersResponse LeaderBoard(GetTopUsers ent)
        {
            var request = new GigyaRequest(ent);
            return request.Send<GetTopUsersResponse>();
        }

        public GetActionConfigResponse ActionConfig(GetActionConfig ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetActionConfigResponse>();
        }

        public GetActionsLogResponse ActionsLog(GetActionsLog ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetActionsLogResponse>();
        }

        public DeleteActionResponse DeleteActions(DeleteAction ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<DeleteActionResponse>();
        }

        public DeleteChallengeResponse DeleteChallange(DeleteChallenge ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<DeleteChallengeResponse>();
        }

        public DeleteChallengeVariantResponse DeleteChallengeVariant(DeleteChallengeVariant ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<DeleteChallengeVariantResponse>();
        }

        public RedeemPointsResponse RedeemPoints(RedeemPoints ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<RedeemPointsResponse>();
        }

        public GetChallengeConfigResponse ChallengeConfig(GetChallengeConfig ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetChallengeConfigResponse>();
        }

        public GetChallengeStatusResponse GetChallengeStatus(GetChallengeStatus ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetChallengeStatusResponse>();
        }

        public GetChallengeVariantsResponse ChallengeVariants(GetChallengeVariants ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetChallengeVariantsResponse>();
        }

        public GetGlobalConfigResponse GlobalConfig(GetGlobalConfig ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetGlobalConfigResponse>();
        }

        public GetTopUsersResponse GetTopUsers(GetTopUsers ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetTopUsersResponse>();
        }

        public NotifyActionResponse NotifyAction(NotifyAction ent)
        {
            var request = new GigyaRequest(ent);
            return request.Send<NotifyActionResponse>();
        }

        public ResetLevelStatusResponse ResetLevelStatus(ResetLevelStatus ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<ResetLevelStatusResponse>();
        }

        public SetActionConfigResponse SetActionConfig(SetActionConfig ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetActionConfigResponse>();
        }

        public SetChallengeConfigResponse SetChallengeConfig(SetChallengeConfig ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetChallengeConfigResponse>();
        }

        public SetGlobalConfigResponse SetGlobalConfig(SetGlobalConfig ent)
        {


            var request = new GigyaRequest(ent);
            return request.Send<SetGlobalConfigResponse>();
        }
    }
}