using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.GM
{
    public partial class NotifyAction : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.notifyAction";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    
    }

    public partial class NotifyAction
    {

        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("action")]
        public string Action { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("points")]
        public int Points { get; set; }

        [DataMember]
        [JsonProperty("challengeIDs")]
        public string ChallengeIDs { get; set; }

    }
}
