using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.Service.Gigya.GM;
using w2.Service.Gigya.Socialize;
using w2.Service.Gigya.Socialize.CustomModels;
using w2.Ws.WS.Core;


namespace w2.Ws
{
    public class UserManagement : BaseWs, IUserManagement
    {
        public NotifyUserLoginResponse Login(NotifyUserLogin userInfo)
        {
            Compability(ref userInfo);
            return _LoginLogic(userInfo, false);
        }

        public void Login()
        {
            PrintJson(Login(null));
        }

        public NotifyUserLoginResponse Register(NotifyUserLogin userInfo)
        {
            Compability(ref userInfo);
            NotifyUserLoginResponse loginResponse = _LoginLogic(userInfo, true);
            return loginResponse;
        }

        public void Register()
        {
            PrintJson(Register(null));
        }

        public NotifyUserLoginResponse _LoginLogic(NotifyUserLogin userInfo, bool newUser)
        {
            Socialize social = new Socialize();
            NotifyUserLoginResponse returnValue = new NotifyUserLoginResponse();
            Service.Gigya.Socialize.NotifyLogin login = new Service.Gigya.Socialize.NotifyLogin();
            login.Cid = userInfo.Cid;
            login.Key = userInfo.Key;
            login.NewUser = newUser;
            login.Msisdn = userInfo.Msisdn;

            NotifyLoginResponse response = social.NotifyLogin(userInfo.Key, login);

            SetDefaults(returnValue, response);

            return returnValue;

        }
        private static void SetDefaults(NotifyUserLoginResponse returnValue, NotifyLoginResponse response)
        {
            returnValue.CallId = response.CallId;
            returnValue.ErrorCode = response.ErrorCode;
            returnValue.ErrorDetails = response.ErrorDetails;
            returnValue.ErrorMessage = response.ErrorMessage;
            returnValue.Msisdn = response.Msisdn;
            returnValue.SignatureTimestamp = response.SignatureTimestamp;
            returnValue.StatusCode = response.StatusCode;
            returnValue.StatusReason = response.StatusReason;
            returnValue.UID = response.UID;
            returnValue.UIDSignature = response.UIDSignature;
        }
        
    }
}
