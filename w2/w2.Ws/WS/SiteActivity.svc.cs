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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SiteActivity" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SiteActivity.svc or SiteActivity.svc.cs at the Solution Explorer and start debugging.
    public class SiteActivity : BaseWs, ISiteActivity
    {
        public NotifyUserLoginResponse SiteLogin(NotifyUserLogin userInfo)
        {
            Compability(ref userInfo);
            UserManagement userManagement=new UserManagement();

            NotifyUserLoginResponse loginResponse = userManagement._LoginLogic(userInfo, false);

            GameMechanic gm = new GameMechanic();
            NotifyAction notify = new NotifyAction();
            notify.ApiKey = w2.Com.Config.App.key;
            notify.Msisdn = userInfo.Msisdn;
            notify.Points = 10;
            notify.UID = w2.Com.Config.Gm.Action._siteLogin.ToString();
            NotifyActionResponse notifyResponse = gm.NotifyAction(notify);

            return loginResponse;
        }

        public void SiteLogin()
        {
            PrintJson(SiteLogin(null));
        }

        public NotifyUserLoginResponse SiteRegister(NotifyUserLogin userInfo)
        {
            Compability(ref userInfo);
            UserManagement userManagement = new UserManagement();
            NotifyUserLoginResponse loginResponse = userManagement._LoginLogic(userInfo, true);

            GameMechanic gm = new GameMechanic();
            NotifyAction notify = new NotifyAction();
            notify.ApiKey = w2.Com.Config.App.key;
            notify.Key = userInfo.Key;
            notify.UID = userInfo.Msisdn;
            notify.Points = 10;
            notify.Action = w2.Com.Config.Gm.Action._newSiteUser.ToString();
            NotifyActionResponse notifyResponse = gm.NotifyAction(notify);

            return loginResponse;
        }

        public void SiteRegister()
        {
            PrintJson(SiteRegister(null));
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
