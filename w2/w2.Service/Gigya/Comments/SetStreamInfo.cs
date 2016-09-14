using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class SetStreamInfo : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.setStreamInfo";
            }
        }

        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [DataMember]
        [JsonProperty("streamTitle")]
        public string StreamTitle { get; set; }

        [DataMember]
        [JsonProperty("streamURL")]
        public string StreamURL { get; set; }

        [DataMember]
        [JsonProperty("streamID")]
        public string StreamID { get; set; }

        [DataMember]
        [JsonProperty("streamInfoSig")]
        public string StreamInfoSig { get; set; }

        [DataMember]
        [JsonProperty("streamTags")]
        public string StreamTags { get; set; }

        [DataMember]
        [JsonProperty("moderationMode")]
        public string ModerationMode { get; set; }

        [DataMember]
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
