using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace w2.Service.Gigya.Comments
{
    public class GetComments : BaseRequest
    {
        [JsonProperty("comments")]
        public Comment[] Comments { get; set; }

        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }

        [JsonProperty("threadCount")]
        public int ThreadCount { get; set; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        //[JsonProperty("streamInfo")]
        //public StreamInfo StreamInfo { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("statusReason")]
        public string StatusReason { get; set; }

        [JsonProperty("callId")]
        public string CallId { get; set; }
    }
}
