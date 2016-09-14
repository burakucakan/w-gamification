using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using w2.Service.Gigya.GM;
using w2.Ws.Models;

namespace w2.Ws
{
    [ServiceContract]
    public interface ILeaderBoard
    {
        [Description("Get All Data")]
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/TopN",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        LeaderListModel TopN(LeaderListRequest request);

        [WebGet]
        [OperationContract(Name = "Json/TopN")]
        [Description("Get All Data")]
        void TopN();

        [Description("Get User Rank")]
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/GetUserRank",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        LeaderListModel GetUserRank(UserRankRequest request);

        [WebGet]
        [OperationContract(Name = "Json/GetUserRank")]
        [Description("Get All Data")]
        void GetUserRank();
        
    }

    [DataContract]
    public class LeaderListModel : BaseWsModel
    {
        [DataMember]
        public List<LeaderModel> Leaders { get; set; }
    }

    [DataContract]
    public class LeaderModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public int Point { get; set; }
    }
    [DataContract]
    public class LeaderListRequest
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
    }
    [DataContract]
    public class UserRankRequest
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Msisdn { get; set; }
    }
}
