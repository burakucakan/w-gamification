using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class GetUserCommentsResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }

        [DataMember]
        [JsonProperty("next")]
        public string Next { get; set; }

        [DataMember]
        [JsonProperty("nextTS")]
        public long NextTS { get; set; }

        [DataMember]
        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }
        
        [DataMember]
        [JsonProperty("context")]
        public string Context { get; set; }

        [DataMember]
        [JsonProperty("comments")]
        public CommentResponse[] Comments { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
