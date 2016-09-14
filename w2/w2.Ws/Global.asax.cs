using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;



namespace w2.Ws
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {            
            RouteTable.Routes.Add(new ServiceRoute("PosTransactions/", new WebServiceHostFactory(), typeof(PosTransactions)));
            RouteTable.Routes.Add(new ServiceRoute("SmsQuery/", new WebServiceHostFactory(), typeof(SmsQuery)));
            RouteTable.Routes.Add(new ServiceRoute("GsmTransactions/", new WebServiceHostFactory(), typeof(GsmTransactions)));
            RouteTable.Routes.Add(new ServiceRoute("Query/", new WebServiceHostFactory(), typeof(Query)));

            RouteTable.Routes.Add(new ServiceRoute("Badge/", new WebServiceHostFactory(), typeof(Badge)));
            RouteTable.Routes.Add(new ServiceRoute("LeaderBoard/", new WebServiceHostFactory(), typeof(LeaderBoard)));
            RouteTable.Routes.Add(new ServiceRoute("SiteActivity/", new WebServiceHostFactory(), typeof(SiteActivity)));
            RouteTable.Routes.Add(new ServiceRoute("UserManagement/", new WebServiceHostFactory(), typeof(UserManagement)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}