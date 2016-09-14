using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class UpdateComment : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.updateComment";
            }
        }

        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [DataMember]
        [JsonProperty("streamID")]
        public string StreamID { get; set; }

        [DataMember]
        [JsonProperty("commentID")]
        public string CommentID { get; set; }

        [DataMember]
        [JsonProperty("commentText")]
        public string CommentText { get; set; }

        [DataMember]
        [JsonProperty("commentTitle")]
        public string CommentTitle { get; set; }

        [DataMember]
        [JsonProperty("status")]
        public string Status { get; set; }

        [DataMember]
        [JsonProperty("flagCount")]
        public int FlagCount { get; set; }

        //[JsonProperty("flagnoteCount")]
        //public object Note { get; set; }

        [DataMember]
        [JsonProperty("flagnoteCount")]
        public string Note { get; set; }

        [DataMember]
        [JsonProperty("IsBlockedUser")]
        public bool isBlockedUser { get; set; }

    }
}
