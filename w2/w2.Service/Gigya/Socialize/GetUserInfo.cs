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
    public partial class GetUserInfo : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.getUserInfo";
            }
        }
        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }


    }

    public partial class GetUserInfo
    {
        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("cid")]
        public string CID { get; set; }

        [DataMember]
        [JsonProperty("includeAllIdentities")]
        public bool IncludeAllIdentities { get; set; }

        [DataMember]
        [JsonProperty("extraFields")]
        public string ExtraFields { get; set; }

        [DataMember]
        [JsonProperty("enabledProviders")]
        public string EnabledProviders { get; set; }

        [DataMember]
        [JsonProperty("disabledProviders")]
        public string DisabledProviders { get; set; }
       
        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

        [DataMember]
        [JsonProperty("includeiRank")]
        public bool IncludeiRank { get; set; }
    }
}
