using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public partial class Vote : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.vote";
            }
        }
        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class Vote
    {

        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("commentID")]
        public string CommentID { get; set; }

        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [DataMember]
        [JsonProperty("streamID")]
        public string StreamID { get; set; }

        [DataMember]
        [JsonProperty("_vote")]
        public string _Vote { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }


    }
}
