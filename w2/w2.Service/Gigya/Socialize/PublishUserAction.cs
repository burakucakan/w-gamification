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
    public partial class PublishUserAction : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.publishUserAction";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class PublishUserAction
    {
        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("userAction")]
        public UserAction UserAction { get; set; }

        [DataMember]
        [JsonProperty("enabledProviders")]
        public string EnabledProviders { get; set; }

        [DataMember]
        [JsonProperty("disabledProviders")]
        public string DisabledProviders { get; set; }

        [DataMember]
        //Optional attribute <provider-name>UserAction
        [JsonProperty("twitterUserAction")]
        public UserAction TwitterUserAction { get; set; }

        [DataMember]
        [JsonProperty("shortURLs")]
        public string ShortURLs { get; set; }

        [DataMember]
        [JsonProperty("cid")]
        public string CID { get; set; }

        [DataMember]
        [JsonProperty("tags")]
        public string Tags { get; set; }


        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

        [DataMember]
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [DataMember]
        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [DataMember]
        [JsonProperty("feedID")]
        public string FeedID { get; set; }

    }
}
