using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Protocols;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;
using w2.Service.Gigya.GM.CustomObjects;
using w2.Ws.Models;

namespace w2.Ws
{
    [ServiceContract]
    public interface IQuery
    {

        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/GetUserTotalPoints",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        
        [Description("Get User Point")]
        UserPoints GetUserTotalPoints(QueryRequest request);

        [WebGet]
        [OperationContract(Name = "Json/GetUserTotalPoints")]
        [Description("Get User Point")]
        void GetUserTotalPoints();

    }


    public class UserPoints : BaseWsModel
    {
        [DataMember]
        public int PointsTotal { get; set; }
    }

    [DataContract]
    public class QueryRequest
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Msisdn { get; set; }
        
    }
}