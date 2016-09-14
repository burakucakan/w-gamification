using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class GetCommentCountsResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("CommentCounts")]
        public CommentCounts CommentCounts { get; set; }

    }
}
