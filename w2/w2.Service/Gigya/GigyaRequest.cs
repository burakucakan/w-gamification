using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gigya.Socialize.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Gigya.Service;
using w2.DB;
using Gigya.DB;

namespace w2.Service.Gigya
{
    public class GigyaRequest
    {
        private BaseRequest reqModel;

        public GigyaRequest(BaseRequest ReqModel)
        {
            this.reqModel = ReqModel;
        }

        public T Send<T>() where T : class, new()
        {
            var retKeyVal = ValidateKey<T>(reqModel.Key);
            if (retKeyVal != null)
                return retKeyVal;

            
            GSResponse response;

            var GsRequest = new GSRequest(reqModel.ApiKey, reqModel.SecretKey, reqModel.Method, w2.Com.Config.App.UseHttps);            

            foreach (var item in this.reqModel.GetType().GetProperties())
            {
                //var propName = item.Name;
                var propName = GetJsonPropertyName(item);
                if (!String.IsNullOrEmpty(propName))
                {

                    var propValue = GetPropertyValue(item, this.reqModel);

                    if (propValue != String.Empty)
                    {
                        var retVal = Validate<T>(item.Name, propValue);

                        if (retVal != null)
                            return retVal;

                        if (propName != String.Empty && GigyaAttributeFilter.IsRequired(item) && propValue != String.Empty)
                            GsRequest.SetParam(propName, propValue);
                    }
                }

            }

            response = GsRequest.Send();
                
            Log(SetLogParams(reqModel,response, GsRequest));           

            return LIB.JsonHelper.ParseJsonObject<T>(response.GetResponseText());
        }

        GigyaLogs SetLogParams(BaseRequest baseReq, GSResponse gsRes, GSRequest gsReq)
        {
            GigyaLogs log = new GigyaLogs();
            log.ApiKey = baseReq.ApiKey;
            log.ApiMethod = baseReq.Method;
            log.ClientParams = gsReq.GetParams().ToJsonString();
            log.Response = gsRes.GetResponseText();
            log.VendorId = Guid.Parse(baseReq.Key);
            
            return log;
        }

        protected void Log(GigyaLogs LogData)
        {
            try
            {
                srvGigyaLogs srvGigya = new srvGigyaLogs();
                srvGigya.Log(LogData);
            }
            catch (Exception) { }
        }

        private string GetJsonPropertyName(PropertyInfo item)
        {
            var attribute = item.GetCustomAttribute(typeof(JsonPropertyAttribute));
            if (attribute == null) return String.Empty;
            var castAttribute = (JsonPropertyAttribute)attribute;
            return castAttribute.PropertyName;
        }

        private string GetPropertyValue(PropertyInfo item, object ReqModel)
        {
            var propValue = item.GetValue(ReqModel, null);
            return propValue == null ? String.Empty : propValue.ToString();
        }


        private T Validate<T>(string propName, string propValue) where T : class, new()
        {
            if ((propName == "Msisdn") && (propValue != String.Empty))
            {
                //Msisdn hatalı
                if (propValue.Length > 10)
                {
                    //response = new GSResponse(
                    BaseResponse defResponse = new BaseResponse();
                    defResponse.ErrorCode = (int)ResponseCodes.ErrorCode.MsisdnStartZero;
                    defResponse.ErrorMessage = "Sifir ile baslamasi lazim";

                    return LIB.JsonHelper.ParseJObject<T>(defResponse);
                }

                /*
            if ((Msisdn.Length >= 11) && (LIB.StringHelper.Left(Msisdn, 1) == "0"))
            {
                this.Defaults.CallId = w2.Com.Config.App.CallIdNoReq;
                this.Defaults.StatusCode = ((int)ResponseCodes.StatusCode.OK).ToString();
                this.Defaults.StatusReason = ResponseCodes.StatusCode.OK.ToString();
                this.Defaults.ErrorDetails = "";
                this.Defaults.ErrorCode = (int)ResponseCodes.ErroCode.MsisdnStartZero;
                this.Defaults.ErrorMessage = Resources.Query.MsisdnStartZero;
            }                 
                 */
            }
            return null;
        }
        private T ValidateKey<T>(string Key) where T : class, new()
        {
            Vendors vendor = srvVendors.GetByAuthKey(Key);

            if (vendor == null || vendor.Id <= 0)
            {
                BaseResponse defResponse = new BaseResponse();
                defResponse.ErrorCode = (int)ResponseCodes.ErrorCode.NoAuthorization;
                defResponse.ErrorMessage = "Hatalı Key";
                return LIB.JsonHelper.ParseJObject<T>(defResponse);
            }
            else
            {
                reqModel.ApiKey = vendor.ApiKey;
                reqModel.SecretKey = vendor.SecretKey;
                return null;
            }
        }

        private bool CheckMsisdn(string Msisdn)
        {

            return true;
        }


    }
}
