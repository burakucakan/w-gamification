using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public partial class GetChallengeStatus : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.getChallengeStatus";
            }
        }

        [DataMember]
        [GigyaParameter(IsRequired = false)]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }
    
    public partial class GetChallengeStatus
    {
        [JsonProperty("uid")]
        public string UID { get; set; }

        [JsonProperty("includeChallenges")]
        public string IncludeChallenges { get; set; }

        [JsonProperty("excludeChallenges")]
        public string ExcludeChallenges { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("extraFields")]
        public string ExtraFields { get; set; }

        [JsonProperty("actionAttributes")]
        public string ActionAttributes { get; set; }

        [JsonProperty("variantID")]
        public string VariantID { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
