using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.GM
{
    public class ActionLogResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("time")]
        public string Time { get; set; }

        [DataMember]
        [JsonProperty("actionID")]
        public string ActionID { get; set; }

        [DataMember]
        [JsonProperty("points")]
        public int Points { get; set; }

        [DataMember]
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [DataMember]
        [JsonProperty("challengeID")]
        public string ChallengeID { get; set; }


    }
}
