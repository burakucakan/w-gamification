using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gnc2.Models;
using MvcHelper.Facebook.Models;

namespace Gnc2.Web.App_Manager
{
    public class SessionManager
    {
        #region Structure
        private System.Web.SessionState.HttpSessionState S;

        //private static SessionManager _sessionManager;

        private SessionManager() { this.S = HttpContext.Current.Session; }

        public static SessionManager GetInstance()
        {
            return new SessionManager();
            /* if (_sessionManager == null)
                 _sessionManager = new SessionManager();
             return _sessionManager;*/
        }

        private void SET(SessionType SessionName, object Value) { S[SessionName.ToString()] = Value; }
        private object GET(SessionType SessionName) { return S[SessionName.ToString()]; }
        #endregion

        public enum SessionType
        {
            AdminId,
            IsLogin,
            LocalMsisdn,
            FacebookId,
            LogonUser,
            IsFbLogin,
            FbUser
        }

        public bool IsLogin
        {
            get { return (GET(SessionType.IsLogin) == null ? false : Convert.ToBoolean(GET(SessionType.IsLogin))); }
            set { SET(SessionType.IsLogin, value); }
        }

        public bool IsFbLogin
        {
            get { return (GET(SessionType.IsFbLogin) == null ? false : Convert.ToBoolean(GET(SessionType.IsFbLogin))); }
            set { SET(SessionType.IsFbLogin, value); }
        }
        public void Destroy()
        {
            S.Clear();
            S.Abandon();
        }

        public int AdminId
        {
            get { return (GET(SessionType.AdminId) == null ? 0 : (int)GET(SessionType.AdminId)); }
            set { SET(SessionType.AdminId, value); }
        }

        public string LocalMsisdn
        {
            get { return (GET(SessionType.LocalMsisdn) == null ? String.Empty : GET(SessionType.LocalMsisdn).ToString()); }
            set { SET(SessionType.LocalMsisdn, value); }
        }
        public string FacebookId
        {
            get { return (GET(SessionType.FacebookId) == null ? String.Empty : GET(SessionType.FacebookId).ToString()); }
            set { SET(SessionType.FacebookId, value); }
        }
        public LogonUserModel LogonUser
        {
            get { return (GET(SessionType.LogonUser) == null ? new LogonUserModel() : (LogonUserModel)GET(SessionType.LogonUser)); }
            set { SET(SessionType.LogonUser, value); }
        }
        public FacebookUser FbUser
        {
            get { return (GET(SessionType.FbUser) == null ? new FacebookUser() : (FacebookUser)GET(SessionType.FbUser)); }
            set { SET(SessionType.FbUser, value); }
        }

    }
}