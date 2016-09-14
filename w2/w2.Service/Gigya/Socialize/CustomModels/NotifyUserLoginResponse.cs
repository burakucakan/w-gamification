using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Socialize.CustomModels
{

    public partial class NotifyUserLoginResponse : BaseResponse
    {

        [DataMember]
        public string Msisdn
        {
            set { UID = LIB.Encryption.Encrypt(value); }
            get { return LIB.Encryption.Decrypt(this.UID); }
        }
    }
    public partial class NotifyUserLoginResponse
    {
        [JsonProperty("UID")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("UIDSignature")]
        public string UIDSignature { get; set; }

        [DataMember]
        [JsonProperty("signatureTimestamp")]
        public string SignatureTimestamp { get; set; }        
    }
}
