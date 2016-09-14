using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using w2.DB;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;
using w2.Service.Gigya.GM.CustomObjects;
using w2.Ws.Models;

namespace w2.Ws
{
    [ServiceContract]
    public interface IPosTransactions
    {        
        [OperationContract]        
        [WebInvoke(
            UriTemplate = "Rest/SendAction",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        [Description("Pos üzerinden gelen kayıtları gamification platformuna aktarır.")]
        PosTransactionResponse SendAction(PosTransactionModel inputObj);

        [WebGet]
        [OperationContract(Name = "Json/SendAction")]
        [Description("Pos üzerinden gelen kayıtları gamification platformuna aktarır.")]
        void SendAction();
    }

    [DataContract]
    public class PosTransactionModel
    {
        [DataMember]
        public string Key { get; set; }

         [DataMember]
        public string Msisdn { get; set; }

        [DataMember]
        public System.DateTime JoinDate { get; set; }

        [DataMember]
        public int Location { get; set; }

        [DataMember]
        public string Campaign { get; set; }

        [DataMember]
        public string Income { get; set; }

        [DataMember]
        public string Amount { get; set; }

        [DataMember]
        public string CampaignType { get; set; }

        [DataMember]
        public string TrId { get; set; }
    }

    [DataContract]
    public class PosTransactionResponse : BaseWsModel
    {

    }
}
