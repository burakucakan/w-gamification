using Gigya.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Gigya.Service
{
    public class srvGigyaLogs:BaseService<GigyaLogs>, IBaseService<GigyaLogs>
    {
        public void Log(GigyaLogs LogData)
        {

            BaseResponse log = LIB.JsonHelper.ParseJsonObject<BaseResponse>(LogData.Response);
            LogData.CallId = log.CallId;
            LogData.ErrorCode = log.ErrorCode;
            Save(LogData);
        } 
    }
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [DataMember]
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [DataMember]
        [JsonProperty("errorDetails")]
        public string ErrorDetails { get; set; }

        [DataMember]
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [DataMember]
        [JsonProperty("statusReason")]
        public string StatusReason { get; set; }

        [DataMember]
        [JsonProperty("callId")]
        public string CallId { get; set; }

        [JsonProperty("ignoredParams")]
        public object[] IgnoredParams { get; set; }
    }
}
