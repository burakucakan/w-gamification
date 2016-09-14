using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public partial class GetThread : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.getThread";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }

    public partial class GetThread
    {


        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("commentID")]
        public string CommentID { get; set; }

        [DataMember]
        [JsonProperty("streamID")]
        public string StreamID { get; set; }

        [DataMember]
        [JsonProperty("threadDepth")]
        public int ThreadDepth { get; set; }

        [DataMember]
        [JsonProperty("includeUID")]
        public bool IncludeUID { get; set; }

        [DataMember]
        [JsonProperty("Sort")]
        public string sort { get; set; }

    }
}
