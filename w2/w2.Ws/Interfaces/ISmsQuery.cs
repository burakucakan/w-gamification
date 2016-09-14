using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using w2.Service.Gigya;
using w2.Ws.Models;

namespace w2.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISmsQuery" in both code and config file together.
    [ServiceContract]
    public interface ISmsQuery
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/GetUserTotalPoints",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        [Description("Gönderilen msisdn değerine karşılık gelen kullanıcının toplam puanını SMS metni içerisinde getirir.")]
        SmsQueryResponse GetUserTotalPoints(SmsQueryRequest data);

        [WebGet]
        [OperationContract(Name = "Json/GetUserTotalPoints")]
        [Description("Gönderilen msisdn değerine karşılık gelen kullanıcının toplam puanını SMS metni içerisinde getirir.")]
        void GetUserTotalPoints();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "Rest/GetActionPoints",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
        ]
        [Description("Gönderilen etkinlik için tanımlanan puanı getirir.")]
        SmsQueryActionResponse GetActionPoints(SmsQueryActionRequest request);

        [WebGet]
        [OperationContract(Name = "Json/GetActionPoints")]
        [Description("Gönderilen etkinlik için tanımlanan puanı getirir.")]
        void GetActionPoints();

    }

    [DataContract]
    public class SmsQueryRequest
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Msisdn { get; set; }
    }

    public class SmsQueryResponse : BaseWsModel
    {
        public int TotalPoints { get; set; }

        public string SmsText
        {
            get
            {
                if (this.ErrorCode == (int)ResponseCodes.GigyaErrorCode.UnauthorizedUser)
                {
                    return Service.Resources.Errors.MsisdnNotFound;
                }
                else if (this.ErrorCode == (int)ResponseCodes.ErrorCode.NoError)
                {
                    if (this.TotalPoints <= Com.Config.App.LowPointLimit)
                        return String.Format(Resources.SmsQuery.LowLimitSmsTemplate, this.TotalPoints);
                    else return String.Format(Resources.SmsQuery.HightLimitSmsTemplate, this.TotalPoints);

                }
                else return String.Empty;

            }
            set { }
        }
    }

    [DataContract]
    public class SmsQueryActionRequest
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string ActionName { get; set; }
    }

    public class SmsQueryActionResponse : BaseWsModel
    {
        public int ActionPoints { get; set; }

        public string SmsText
        {
            get
            {
                if (ErrorCode == (int)ResponseCodes.GigyaErrorCode.NoError)
                    return String.Format(Resources.SmsQuery.CampaignPointSmsTemplate, ActionPoints);
                else return String.Empty;

            }
            set { }
        }
    }
}
