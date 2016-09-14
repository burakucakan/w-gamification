using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Socialize
{
    public class Yahoo : BaseRequest
    {
        [DataMember]
        [JsonProperty("authToken")]
        public string AuthToken { get; set; }

        [DataMember]
        [JsonProperty("tokenSecret")]
        public string TokenSecret { get; set; }

        [DataMember]
        [JsonProperty("tokenExpiration")]
        public string TokenExpiration { get; set; }

    }
}
