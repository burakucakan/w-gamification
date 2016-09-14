using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using w2.Service.Gigya.Socialize.CustomModels;
using System.ComponentModel;
using w2.Service.Gigya;
using w2.Ws.Models;

namespace w2.Ws
{
    [ServiceContract]
    public interface ISiteActivity
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/SiteLogin",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        NotifyUserLoginResponse SiteLogin(NotifyUserLogin userInfo);

        [WebGet]
        [OperationContract(Name = "Json/SiteLogin")]
        [Description("")]
        void SiteLogin();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/SiteRegister",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        NotifyUserLoginResponse SiteRegister(NotifyUserLogin userInfo);

        [WebGet]
        [OperationContract(Name = "Json/SiteRegister")]
        [Description("")]
        void SiteRegister();
    }
}
