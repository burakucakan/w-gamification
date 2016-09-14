using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using w2.Ws.Models;

namespace w2.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGSMTransaction" in both code and config file together.
    [ServiceContract]
    public interface IGsmTransactions
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/SendAction",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        [Description("")]
        GsmTransactionResponse SendAction(GsmTransactionRequest request);
        
        [OperationContract(Name="Json/SendAction")]
        [WebGet]
        [Description("")]
        void SendAction();


        [OperationContract]
        [WebInvoke(
            UriTemplate = "SendActionList",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        [Description("")]
        List<GsmTransactionResponse> SendMultipleAction(GsmTransactionMultipleRequest request);
    }
    [DataContract]
    public class GsmTransactionRequest
    {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string ActionName { get; set; }

        [DataMember]
        public string Msisdn { get; set; }

        [DataMember]
        public int TransactionId { get; set; }

        [DataMember]
        public bool? IsSendSms { get; set; }    

    }
    [DataContract]
    public class GsmTransactionResponse : BaseWsModel
    {
        public int TransactionId { get; set; }
    }

    [DataContract]
    public class GsmTransactionMultipleRequest
    {
        [DataMember]
        public string Key { get; set; }
        
        [DataMember]
        public List<GsmTransactionRequest> Actions { get; set; }
    }

}
