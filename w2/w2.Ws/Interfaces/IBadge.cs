using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using w2.Service.Gigya;
using w2.Ws.Models;

namespace w2.Ws
{
    [ServiceContract]
    public interface IBadge
    {
        [Description("Get All Badge")]
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/GetAll",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        BadgeListQueryRequest GetAll(BadgeListQueryReq request);

        [WebGet]
        [OperationContract(Name = "Json/GetAll")]
        [Description("Get All Badge")]
        void GetAll();



        [Description("Get N Random")]
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/GetNRandom",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]

        BadgeListQueryRequest GetNRandom(BadgeListQueryReq request);

        [WebGet]
        [OperationContract(Name = "Json/GetNRandom")]
        [Description("Get N Random")]
        void GetNRandom();

        [Description("Get User Badge")]
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/GetUserBadge",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]

        BadgeUserListModel GetUserBadge(BadgeListQueryReq request);

        [WebGet]
        [OperationContract(Name = "Json/GetUserBadge")]
        [Description("Get User Badge")]
        void GetUserBadge();

    }

    [DataContract]
    public class BadgeListQueryRequest : BaseWsModel
    {
        [DataMember]
        public List<BadgeModel> Badges { get; set; }

    }

    [DataContract]
    public class BadgeModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }

    }

   


    [DataContract]
    public class BadgeUserListModel : BaseWsModel
    {
        [DataMember]
        public List<UserBadgeModel> Badges { get; set; }

    }

    [DataContract]
    public class UserBadgeModel
    {
        [DataMember]
        public string ChallengeID { get; set; }
        
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int PointsTotal { get; set; }
        
        [DataMember]
        public int Points7Days { get; set; }

        [DataMember]
        public int Rank { get; set; }

        [DataMember]
        public int Rank7Days { get; set; }

        [DataMember]
        public string BadgeURL { get; set; }
    }


    [DataContract]
    public class BadgeListQueryReq
    {
        [DataMember]
        public int NTop { get; set; }

        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Msisdn { get; set; }
    }

}
