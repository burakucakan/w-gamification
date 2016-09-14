using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class GetTopStreamsResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("streams")]
        public Stream[] Streams { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
