using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace wSrvLocatorLibrary
{
    [ServiceContract]
    public interface ISmsService
    {
        [OperationContract]
        SmsServiceResult SendSms(string AppId, string Msisdn, string SmsText);
        
        [OperationContract]
        SmsServiceResult NewTicket(string AppId, string Msisdn);
    }

    [DataContract]
    public class SmsServiceResult
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
