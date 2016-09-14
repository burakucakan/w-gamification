using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.GM
{
    public partial class ResetLevelStatus : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.resetLevelStatus";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }

    public partial class ResetLevelStatus
    {

        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("challenges")]
        public string Challenges { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("actionAttributes")]
        public string actionAttributes { get; set; }

        [DataMember]
        [JsonProperty("variantID")]
        public string CariantID { get; set; }


    }
}
