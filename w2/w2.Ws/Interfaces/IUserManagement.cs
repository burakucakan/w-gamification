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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INotifyLogin" in both code and config file together.
    [ServiceContract]
    public interface IUserManagement
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/Login",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        NotifyUserLoginResponse Login(NotifyUserLogin userInfo);

        [WebGet]
        [OperationContract(Name = "Json/Login")]
        [Description("")]
        void Login();
        
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/Register",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        NotifyUserLoginResponse Register(NotifyUserLogin userInfo);

        [WebGet]
        [OperationContract(Name = "Json/Register")]
        [Description("")]
        void Register();
    }
}
