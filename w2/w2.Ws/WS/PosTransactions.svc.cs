using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using w2.DB;
using w2.Service.Gigya;
using w2.Service.Gigya.GM;
//using w2.Service.Gigya.GM.CustomObjects;
using w2.Ws.Models;
//using w2.Service.Resources;
using w2.Service;
using w2.Ws.Resources;
using w2.Ws.WS.Core;

namespace w2.Ws
{
    public class PosTransactions : BaseWs, IPosTransactions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="inputObj"></param>
        /// <returns></returns>
        public PosTransactionResponse SendAction(PosTransactionModel inputObj)
        {

            Compability(ref inputObj);

            PosTransactionResponse returnResponse = new PosTransactionResponse();
            if (inputObj == null)
            {
                returnResponse.ErrorCode = (int)ResponseCodes.ErrorCode.MissingParameter;
                returnResponse.ErrorMessage = Resources.GsmTransactions.MissingParameter;
                return returnResponse;
            }
            GameMechanic gm = new GameMechanic();
            NotifyAction action = new Service.Gigya.GM.NotifyAction();
            
            action.Action = inputObj.Campaign;
            action.Key = inputObj.Key;
            action.Msisdn = inputObj.Msisdn;

            NotifyActionResponse response = gm.NotifyAction(action);
            returnResponse.SetDefaults(response);
            

            SaveAction(inputObj);

            VendorLogs log = new VendorLogs();
            log.AuthKey = inputObj.Key;
            log.CallId = response.CallId;
            log.Msisdn = inputObj.Msisdn;
            Log(log);

            return returnResponse;
        }
        public void SendAction()
        {
            PrintJson(SendAction(null));
        }
        private void SaveAction(PosTransactionModel model)
        {
            PosTransaction action = new PosTransaction();
            action.Amount = model.Amount;
            action.Campaign = model.Campaign;
            action.CampaignType = model.CampaignType;
            action.CreateDate = DateTime.Now;
            action.Msisdn = model.Msisdn;
            action.TrId = model.TrId;
            action.JoinDate = model.JoinDate;
            action.Income = model.Income;
            action.Location = model.Location;
            srvGmTransactionActions srv = new srvGmTransactionActions();
            srv.Save(action);
        }        

    }
}
