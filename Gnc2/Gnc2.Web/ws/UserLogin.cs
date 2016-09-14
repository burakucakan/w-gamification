using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gnc2.Web.App_Manager;

namespace Gnc2.Ws
{
    public class UserLogin
    {
        protected SessionManager session { get { return SessionManager.GetInstance(); } }
        public void SessionCreate(string Msisdn)
        {
            session.LocalMsisdn = Msisdn;
        }
    }
}