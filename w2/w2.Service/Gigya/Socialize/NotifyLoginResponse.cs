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
    public partial class NotifyLoginResponse : BaseResponse
    {

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }

    public partial class NotifyLoginResponse
    {

        [JsonProperty("UID")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("UIDSignature")]
        public string UIDSignature { get; set; }

        [DataMember]
        [JsonProperty("signatureTimestamp")]
        public string SignatureTimestamp { get; set; }

        [DataMember]
        [JsonProperty("cookieName")]
        public string CookieName { get; set; }

        [DataMember]
        [JsonProperty("cookieValue")]
        public string CookieValue { get; set; }

        [DataMember]
        [JsonProperty("cookieDomain")]
        public string CookieDomain { get; set; }

        [DataMember]
        [JsonProperty("cookiePath")]
        public string CookiePath { get; set; }

        [DataMember]
        [JsonProperty("sessionToken")]
        public string SessionToken { get; set; }

        [DataMember]
        [JsonProperty("sessionSecret")]
        public string SessionSecret { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
