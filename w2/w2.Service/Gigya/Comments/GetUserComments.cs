using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public partial class GetUserComments : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.getUserComments";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class GetUserComments
    {

        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [DataMember]
        [JsonProperty("streamID")]
        public string StreamID { get; set; }

        [DataMember]
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [DataMember]
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [DataMember]
        [JsonProperty("start")]
        public string Start { get; set; }

        [DataMember]
        [JsonProperty("includeNote")]
        public bool IncludeNote { get; set; }
    }
}
