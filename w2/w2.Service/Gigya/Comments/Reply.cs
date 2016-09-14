using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class Reply
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("parentID")]
        public string ParentID { get; set; }

        [JsonProperty("threadID")]
        public string ThreadID { get; set; }

        [JsonProperty("commentText")]
        public string CommentText { get; set; }

        [JsonProperty("sender")]
        public Sender2 Sender { get; set; }

        [JsonProperty("providerPostIDs")]
        public string ProviderPostIDs { get; set; }

        [JsonProperty("flagCount")]
        public int FlagCount { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("threadTimestamp")]
        public long ThreadTimestamp { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
