using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public partial class GetChallengeStatusResponse : BaseResponse
    {
        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class GetChallengeStatusResponse
    {
        [JsonProperty("UID")]
        protected string UID { get; set; }

        [DataMember]
        [JsonProperty("achievements")]
        public Achievement[] Achievements { get; set; }

    }
}
