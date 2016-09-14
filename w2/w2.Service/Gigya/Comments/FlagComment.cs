using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Comments
{
    public partial class FlagComment : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.flagComment";
            }
        }
        
        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }
    public partial class FlagComment
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
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
