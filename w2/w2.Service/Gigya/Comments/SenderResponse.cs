using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class SenderResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("photoURL")]
        public string PhotoURL { get; set; }

        [DataMember]
        [JsonProperty("profileURL")]
        public string ProfileURL { get; set; }

        [DataMember]
        [JsonProperty("loginProvider")]
        public string LoginProvider { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("isSelf")]
        public bool IsSelf { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
