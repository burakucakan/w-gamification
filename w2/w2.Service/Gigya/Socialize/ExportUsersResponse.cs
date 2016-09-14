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
    public class ExportUsersResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("users")]
        public User Users { get; set; }

        [DataMember]
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }

        [DataMember]
        [JsonProperty("identitiesCount")]
        public int IdentitiesCount { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
