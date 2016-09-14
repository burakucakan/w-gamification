using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Socialize
{
    public class UserAction : BaseRequest
    {

        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        [DataMember]
        [JsonProperty("src")]
        public string Src { get; set; }

        [DataMember]
        [JsonProperty("href")]
        public string Href { get; set; }

        [DataMember]
        [JsonProperty("width")]
        public int Width { get; set; }

        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }

        [DataMember]
        [JsonProperty("previewImageURL")]
        public string PreviewImageURL { get; set; }

        [DataMember]
        [JsonProperty("previewImageWidth")]
        public int PreviewImageWidth { get; set; }

        [DataMember]
        [JsonProperty("previewImageHeight")]
        public int previewImageHeight { get; set; }

        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        [DataMember]
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [DataMember]
        [JsonProperty("album")]
        public string Album { get; set; }

    }
}
