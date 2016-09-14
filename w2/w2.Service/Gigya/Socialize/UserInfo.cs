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
    public class UserInfo : BaseRequest
    {

        [DataMember]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }


        [DataMember]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [DataMember]
        [JsonProperty("age")]
        public int Age { get; set; }

    }
}
