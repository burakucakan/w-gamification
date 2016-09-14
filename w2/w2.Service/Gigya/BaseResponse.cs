using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace w2.Service.Gigya
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [DataMember]
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [IgnoreDataMember]
        [JsonProperty("errorDetails")]
        public string ErrorDetails { get; set; }

        [IgnoreDataMember]
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [IgnoreDataMember]
        [JsonProperty("statusReason")]
        public string StatusReason { get; set; }

        [DataMember]
        [JsonProperty("callId")]
        public string CallId { get; set; }

        [IgnoreDataMember]
        [JsonProperty("ignoredParams")]
        public object[] IgnoredParams { get; set; }
    }
}