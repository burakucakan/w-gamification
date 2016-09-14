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
    public class Identity : BaseRequest
    {
        [DataMember]
        [JsonProperty("facebook")]
        public w2.Service.Gigya.Socialize.Identities.IFacebook Facebbok { get; set; }
        
        [DataMember]
        [JsonProperty("linkedin")]
        public w2.Service.Gigya.Socialize.Identities.ILinkedin Linkedin { get; set; }

    }
}
