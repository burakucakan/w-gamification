using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.DB;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;
using w2.Service.Resources;
using w2.Ws.Resources;
using w2.Ws.WS.Core;

namespace w2.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GSMTransaction" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GSMTransaction.svc or GSMTransaction.svc.cs at the Solution Explorer and start debugging.
    public class GsmTransactions : BaseWs, IGsmTransactions
    {
        public GsmTransactionResponse SendAction(GsmTransactionRequest request)
        {
            Compability(ref request);
            VendorLogs log = new VendorLogs();
            GameMechanic gm = new GameMechanic();
            NotifyAction action = new NotifyAction();
            GsmTransactionResponse returnResponse = new GsmTransactionResponse();
            NotifyActionResponse response;

            if (request == null)
            {
                returnResponse.ErrorCode = (int)ResponseCodes.ErrorCode.MissingParameter;
                returnResponse.ErrorMessage = Resources.GsmTransactions.MissingParameter;
                return returnResponse;
            }

            action.Action = request.ActionName;
            action.Key = request.Key;
            action.Msisdn = request.Msisdn;

            response = gm.NotifyAction(action);
            returnResponse.SetDefaults(response);

            if (response.ErrorCode == (int)ResponseCodes.ErrorCode.NoError && (request.IsSendSms.Value || request.IsSendSms == null))
                GetActionInfoAndSendSms(request.ActionName, request.Key, request.Msisdn);

            log.AuthKey = request.Key;
            log.CallId = response.CallId;
            log.Msisdn = request.Msisdn;
            Log(log);



            return returnResponse;

        }

        public void SendAction() {
            PrintJson(SendAction(null));
        }


        public List<GsmTransactionResponse> SendMultipleAction(GsmTransactionMultipleRequest request)
        {
            VendorLogs log = new VendorLogs();
            GameMechanic gm = new GameMechanic();
            NotifyAction action;
            List<GsmTransactionResponse> responseList = new List<GsmTransactionResponse>();
            GsmTransactionResponse singleResponse;
            NotifyActionResponse response;

            if (request == null)
            {
                singleResponse = new GsmTransactionResponse();
                singleResponse.ErrorCode = (int)ResponseCodes.ErrorCode.MissingParameter;
                singleResponse.ErrorMessage = Resources.GsmTransactions.MissingParameter;
                responseList.Add(singleResponse);
                return responseList;
            }

            foreach (GsmTransactionRequest req in request.Actions)
            {
                singleResponse = new GsmTransactionResponse();
                action = new NotifyAction();
                action.Action = req.ActionName;
                action.Key = request.Key;
                action.Msisdn = req.Msisdn;
                response = gm.NotifyAction(action);
                singleResponse.SetDefaults(response);
                singleResponse.TransactionId = req.TransactionId;
                responseList.Add(singleResponse);

                if (response.ErrorCode == (int)ResponseCodes.ErrorCode.NoError && (req.IsSendSms.Value || req.IsSendSms == null))
                    GetActionInfoAndSendSms(req.ActionName, request.Key, req.Msisdn);

            }
            return responseList;
        }
        private string SendSms(string smsText, string Msisdn)
        {

            SmsService.SmsService srv = new SmsService.SmsService();
            string AppId = ConfigurationManager.AppSettings["PennaAppId"];
            SmsService.SmsServiceResult result = srv.SendSms(AppId, Msisdn, smsText);
            return result.Message;
        }

        private SmsQueryActionResponse GetActionInfo(string ActionName, string Key)
        {

            SmsQueryActionRequest req = new SmsQueryActionRequest();
            SmsQueryActionResponse response = new SmsQueryActionResponse();
            req.ActionName = ActionName;
            req.Key = Key;

            SmsQuery sms = new SmsQuery();
            response = sms.GetActionPoints(req);
            return response;

        }
        private void GetActionInfoAndSendSms(string ActionName, string Key, string Msisdn)
        {
            SmsQueryActionResponse response = GetActionInfo(ActionName, Key);
            if (response.ErrorCode == (int)ResponseCodes.ErrorCode.NoError)
                SendSms(response.SmsText, Msisdn);
        }

    }
}
