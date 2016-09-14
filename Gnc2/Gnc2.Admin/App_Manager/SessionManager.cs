using Gnc2.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnc2.Admin.App_Manager
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
            IsLogin,
            AdminId,
            Username,
            Email,
            FirstName,
            LastName,
            UserPhoto,
            Permissions,
            Photo,
            FullAuth,
            LastLoginDate,

            LastUploadedFile,
            PromoCodesTextFilePath,
            PromoCodesTextFileName,
            PromoCodesFileStream
        }

        public bool IsLogin
        {
            get { return (GET(SessionType.IsLogin) == null ? false : Convert.ToBoolean(GET(SessionType.IsLogin))); }
            set { SET(SessionType.IsLogin, value); }
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

        public string Username
        {
            get { return (GET(SessionType.Username) == null ? String.Empty : GET(SessionType.Username).ToString()); }
            set { SET(SessionType.Username, value); }
        }

        public string FirstName
        {
            get { return (GET(SessionType.FirstName) == null ? String.Empty : GET(SessionType.FirstName).ToString()); }
            set { SET(SessionType.FirstName, value); }
        }

        public string LastName
        {
            get { return (GET(SessionType.LastName) == null ? String.Empty : GET(SessionType.LastName).ToString()); }
            set { SET(SessionType.LastName, value); }
        }

        public string UserPhoto
        {
            get { return (GET(SessionType.UserPhoto) == null ? String.Empty : GET(SessionType.UserPhoto).ToString()); }
            set { SET(SessionType.UserPhoto, value); }
        }

        public DateTime? LastLoginDate
        {
            get { return (DateTime?)(GET(SessionType.LastLoginDate)); }
            set { SET(SessionType.LastLoginDate, value); }
        }

        public string LastUploadedFile
        {
            get { return (GET(SessionType.LastUploadedFile) == null ? String.Empty : GET(SessionType.LastUploadedFile).ToString()); }
            set { SET(SessionType.LastUploadedFile, value); }
        }


        public string PromoCodesTextFilePath
        {
            get { return (GET(SessionType.PromoCodesTextFilePath) == null ? String.Empty : GET(SessionType.PromoCodesTextFilePath).ToString()); }
            set { SET(SessionType.PromoCodesTextFilePath, value); }
        }


        public string PromoCodesTextFileName
        {
            get { return (GET(SessionType.PromoCodesTextFileName) == null ? String.Empty : GET(SessionType.PromoCodesTextFileName).ToString()); }
            set { SET(SessionType.PromoCodesTextFileName, value); }
        }


        public HttpPostedFileBase PromoCodesFileStream
        {
            get { return (GET(SessionType.PromoCodesFileStream) == null ? null : (HttpPostedFileBase)GET(SessionType.PromoCodesFileStream)); }
            set { SET(SessionType.PromoCodesFileStream, value); }
        }


        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public bool FullAuth
        {
            get { return (GET(SessionType.FullAuth) == null ? false : Convert.ToBoolean(GET(SessionType.FullAuth))); }
            set { SET(SessionType.FullAuth, value); }
        }

        public List<PanelMenuModel> Permissions
        {
            get
            {
                if (GET(SessionType.Permissions) == null) return null;
                return (List<PanelMenuModel>)(GET(SessionType.Permissions));
            }
            set { SET(SessionType.Permissions, value); }
        }


    }
}