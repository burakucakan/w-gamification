using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.GM
{
    public class Stream
    {
        [JsonProperty("streamID")]
        public string StreamID { get; set; }

        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createDate")]
        public object CreateDate { get; set; }

        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }

        [JsonProperty("threadCount")]
        public int ThreadCount { get; set; }

        [JsonProperty("streamTitle")]
        public string StreamTitle { get; set; }

        [JsonProperty("streamURL")]
        public string StreamURL { get; set; }

        [JsonProperty("rssURL")]
        public string RssURL { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
