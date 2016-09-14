using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace w2.Service.Gigya.Socialize
{
    public partial class DeleteAccount : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.deleteAccount";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class DeleteAccount
    {


        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("cid")]
        public string CID { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
