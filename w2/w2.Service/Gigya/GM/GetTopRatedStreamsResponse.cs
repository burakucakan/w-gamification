using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.GM
{
    public class GetTopRatedStreamsResponse : BaseResponse
    {
        [JsonProperty("streams")]
        public Stream[] Streams { get; set; }


    }
}
