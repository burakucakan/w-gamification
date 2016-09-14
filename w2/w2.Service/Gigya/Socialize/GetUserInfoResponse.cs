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
    public partial class GetUserInfoResponse : BaseResponse
    {
        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }

    public partial class GetUserInfoResponse
    {


        [JsonProperty("UID")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("isSiteUser")]
        public bool IsSiteUser { get; set; }

        [DataMember]
        [JsonProperty("isConnected")]
        public bool IsConnected { get; set; }

        [DataMember]
        [JsonProperty("isLoggedIn")]
        public bool IsLoggedIn { get; set; }

        [DataMember]
        [JsonProperty("isTempUser")]
        public bool IsTempUser { get; set; }

        [DataMember]
        [JsonProperty("loginProvider")]
        public string LoginProvider { get; set; }

        [DataMember]
        [JsonProperty("loginProviderUID")]
        public string LoginProviderUID { get; set; }

        [DataMember]
        [JsonProperty("isSiteUID")]
        public bool IsSiteUID { get; set; }

        [DataMember]
        [JsonProperty("identities")]
        public bool Identities { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
