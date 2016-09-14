using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Socialize
{
    public class SetStatusResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("providerErrorCodes")]
        public ProviderErrorCodeResponse ProviderErrorCodes { get; set; }
    }
}
