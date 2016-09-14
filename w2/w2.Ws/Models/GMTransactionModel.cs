using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using w2.DB;
using w2.Service;
using w2.Service.Gigya;
using w2.Service.Resources;
using w2.Ws.Resources;

namespace w2.Ws.Models
{
    public class GMTransactionModel :PosTransaction
    {
        public static T ValidateKey<T>(string Key) where T : class, new()
        {
            Vendors vendor = srvVendors.GetByAuthKey(Key);

            if (vendor == null || vendor.Id <= 0)
            {
                BaseResponse defResponse = new BaseResponse();
                defResponse.ErrorCode = (int)ResponseCodes.ErrorCode.NoAuthorization;
                defResponse.ErrorMessage = Resources.GsmTransactions.NoAuthorizationErrorMessage;
                return LIB.JsonHelper.ParseJObject<T>(defResponse);
            }
            else
                return LIB.JsonHelper.ParseJObject<T>(vendor);
        }


    }
}