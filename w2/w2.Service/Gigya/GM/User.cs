using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.GM
{
    [DataContract]
    public class User
    {
        [DataMember]
        [JsonProperty("UID")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("photoURL")]
        public string PhotoURL { get; set; }

        [DataMember]
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        [DataMember]
        [JsonProperty("achievements")]
        public Achievement[] Achievements { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
