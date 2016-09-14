using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Socialize
{
    public partial class SetStatus : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.setStatus";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }

    public partial class SetStatus
    {

        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("status")]
        public string Status { get; set; }

        [DataMember]
        [JsonProperty("cid")]
        public string CID { get; set; }

        [DataMember]
        [JsonProperty("enabledProviders")]
        public string EnabledProviders { get; set; }

        [DataMember]
        [JsonProperty("disabledProviders")]
        public string DisabledProviders { get; set; }

        // Error
        [DataMember]
        [JsonProperty("userLocation")]
        public GetPlaces UserLocation { get; set; }

        [DataMember]
        [JsonProperty("shortURLs")]
        public string ShortURLs { get; set; }


        // Error
        [DataMember]
        [JsonProperty("context")]
        public string Context { get; set; }


        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public string HttpStatusCodes { get; set; }
    }
}
