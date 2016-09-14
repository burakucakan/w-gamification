using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Gnc2.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogin" in both code and config file together.
    [ServiceContract]
    public interface IUser
    {
        //User Login
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/Login",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        [Description("User Login Call")]
        LoginResponse Login(LoginRequest request);

        [WebGet]
        [OperationContract(Name = "Json/Login")]
        [Description("User Login Call")]
        void Login();

        //User Logout
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/Logout",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        [Description("User Logout Call")]
        LogoutResponse Logout(LogoutRequest request);

        [WebGet]
        [OperationContract(Name = "Json/Logout")]
        [Description("User Logout Call")]
        void Logout();
    }
    [DataContract]
    public class LoginRequest
    {
        [DataMember]
        public string Provider { get; set; }

        [DataMember]
        public bool IsGncMember { get; set; }

        [DataMember]
        public string FacebookId { get; set; }

        [DataMember]
        public string Msisdn { get; set; }

    }
    [DataContract]
    public class LoginResponse
    {
        public bool Status { get; set; }
    }

    [DataContract]
    public class LogoutRequest
    {
        [DataMember]
        public string Provider { get; set; }

        [DataMember]
        public bool IsGncMember { get; set; }

        [DataMember]
        public string FacebookId { get; set; }

        [DataMember]
        public int Msisdn { get; set; }

    }
    [DataContract]
    public class LogoutResponse
    {
        public bool Status { get; set; }
    }
}
