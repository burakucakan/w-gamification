using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class GetTopStreams : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.getTopStreams";
            }
        }

        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [DataMember]
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [DataMember]
        [JsonProperty("maxStreamAge")]
        public int MaxStreamAge { get; set; }

        [DataMember]
        [JsonProperty("includeLastComment")]
        public bool IncludeLastComment { get; set; }

        [DataMember]
        [JsonProperty("streamTag")]
        public string StreamTag { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }
    }
}
