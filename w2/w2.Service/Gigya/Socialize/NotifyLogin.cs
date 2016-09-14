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

    public partial class NotifyLogin : BaseRequest
    {

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(SiteUID) ? String.Empty : LIB.Encryption.Decrypt(SiteUID); }
            set { SiteUID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class NotifyLogin : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.notifyLogin";
            }
        }

        [DataMember]
        [JsonProperty("siteUID")]
        public string SiteUID { get; set; }

        [DataMember]
        [JsonProperty("cid")]
        public string Cid { get; set; }

        [DataMember]
        [JsonProperty("sessionExpiration")]
        public int SessionExpiration { get; set; }

        [DataMember]
        [JsonProperty("newUser")]
        public bool NewUser { get; set; }

        [DataMember]
        [JsonProperty("UserInfo")]
        public UserInfo UserInfo { get; set; }

        [DataMember]
        [JsonProperty("providerSessions")]
        public ProviderSessions ProviderSessions { get; set; }

        [DataMember]
        [JsonProperty("targetEnv")]
        public string TargetEnv { get; set; }

        [DataMember]
        [JsonProperty("uidSig")]
        public string UIDSig { get; set; }

        [DataMember]
        [JsonProperty("uidTimestamp")]
        public string UIDTimestamp { get; set; }

        //Burası JSON object alıyor fakat aldığı attribute sayısı ve türü belli değil
        [DataMember]
        [JsonProperty("actionAttributes")]
        public string ActionAttributes { get; set; }

    }
}
