using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.Service.Gigya;
using w2.Service.Gigya.Socialize;
using w2.Service.Gigya.Socialize.Identities;

namespace w2.Ws.WS.Core
{
    public class Socialize
    {
        public DeleteAccountResponse DeleteAccount(string Key, DeleteAccount ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<DeleteAccountResponse>();
        }

        public DelUserSettingsResponse DelUserSetting(string Key, DelUserSettings ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<DelUserSettingsResponse>();
        }

        public ExportUsersResponse ExportUsers(string Key, ExportUsers ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<ExportUsersResponse>();
        }

        public GetUserInfoResponse GetUserInfo(string Key, GetUserInfo ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetUserInfoResponse>();
        }

        public GetUserSettingsResponse GetUserSettings(string Key, GetUserSettings ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetUserSettingsResponse>();
        }

        public LogoutResponse Logout(string Key, Logout ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<LogoutResponse>();
        }

        public NotifyLoginResponse NotifyLogin(string Key, NotifyLogin ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<NotifyLoginResponse>();
        }

        public NotifyRegistrationResponse NotifyRegistration(string Key, NotifyRegistration ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<NotifyRegistrationResponse>();
        }

        public ProviderErrorCodeResponse ProviderErrorCode(string Key, ProviderErrorCode ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<ProviderErrorCodeResponse>();
        }

        public PublishUserActionResponse PublishUserAction(string Key, PublishUserAction ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<PublishUserActionResponse>();
        }

        public SetStatusResponse SetStatus(string Key, SetStatus ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetStatusResponse>();
        }

        public SetUIDResponse SetUID(string Key, SetUID ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetUIDResponse>();
        }

        public SetUserInfoResponse SetUserInfo(string Key, SetUserInfo ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetUserInfoResponse>();
        }

        public SetUserSettingsResponse SetUserSettings(string Key, SetUserSettings ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetUserSettingsResponse>();
        }
    }
}