using System;
using wSrvConnector.ServiceModels;

namespace wSrvConnector
{
    public interface ISmsService : IServiceConnector
    {
        SmsServiceResult SendSms(string AppId, string Msisdn, string SmsText);
        SmsServiceResult NewTicket(string AppId, string Msisdn);
    }
}
