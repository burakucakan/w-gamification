using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public partial class GetTopUsers : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.getTopUsers";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID)? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class GetTopUsers
    {
        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        [DataMember]
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [DataMember]
        [JsonProperty("friendsCount")]
        public int FriendsCount { get; set; }

        [DataMember]
        [JsonProperty("includeSelf")]
        public bool IncludeSelf { get; set; }

        [DataMember]
        [JsonProperty("period")]
        public string Period { get; set; }

        [DataMember]
        [JsonProperty("actionAttributes")]
        public string ActionAttributes { get; set; }

        [DataMember]
        [JsonProperty("variantID")]
        public string VariantID { get; set; }

        [DataMember]
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }


    }
}
