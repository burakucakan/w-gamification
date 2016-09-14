using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class CommentResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("ID")]
        public string ID { get; set; }

        [DataMember]
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [DataMember]
        [JsonProperty("streamId")]
        public string StreamId { get; set; }

        [DataMember]
        [JsonProperty("threadID")]
        public string ThreadID { get; set; }

        [DataMember]
        [JsonProperty("commentText")]
        public string CommentText { get; set; }

        //[JsonProperty("sender")]
        //public SenderResponse Sender { get; set; }

        [DataMember]
        [JsonProperty("posVotes")]
        public int PosVotes { get; set; }

        [DataMember]
        [JsonProperty("vote")]
        public string Vote { get; set; }

        [DataMember]
        [JsonProperty("flagCount")]
        public int FlagCount { get; set; }

        //[JsonProperty("timestamp")]
        //public object Timestamp { get; set; }

        //[JsonProperty("threadTimestamp")]
        //public object ThreadTimestamp { get; set; }

        [DataMember]
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [DataMember]
        [JsonProperty("threadTimestamp")]
        public string ThreadTimestamp { get; set; }

        [DataMember]
        [JsonProperty("status")]
        public string Status { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
