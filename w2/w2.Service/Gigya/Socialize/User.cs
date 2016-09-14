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
    public partial class User : BaseRequest
    {
        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }

    public partial class User
    {
        [JsonProperty("UID")]
        public string UID { get; set; }

        //[JsonProperty("identities")]
        //public Identity Identities { get; set; }

    }

}

