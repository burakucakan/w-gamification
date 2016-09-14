using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class Comment : BaseRequest
    {
     
        [DataMember]
        [JsonProperty("ID")]
        public string ID { get; set; }

        [DataMember]
        [JsonProperty("threadID")]
        public string ThreadID { get; set; }

        [DataMember]
        [JsonProperty("commentText")]
        public string CommentText { get; set; }

        [DataMember]
        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        [DataMember]
        [JsonProperty("providerPostIDs")]
        public string ProviderPostIDs { get; set; }

        [DataMember]
        [JsonProperty("flagCount")]
        public int FlagCount { get; set; }

        [DataMember]
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [DataMember]
        [JsonProperty("threadTimestamp")]
        public long ThreadTimestamp { get; set; }

        [DataMember]
        [JsonProperty("replies")]
        public Reply[] Replies { get; set; }

    }
}
