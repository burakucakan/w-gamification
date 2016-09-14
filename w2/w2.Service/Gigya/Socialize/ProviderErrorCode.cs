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
    public class ProviderErrorCode : BaseRequest
    {
        [DataMember]
        [JsonProperty("provider")]
        public string Provider { get; set; }

    }
}
