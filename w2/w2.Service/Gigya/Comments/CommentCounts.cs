using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class CommentCounts
    {
        [JsonProperty("pending")]
        public int Pending { get; set; }

        [JsonProperty("published")]
        public int Published { get; set; }

        [JsonProperty("rejected")]
        public int Rejected { get; set; }

        [JsonProperty("flagged")]
        public int Flagged { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
