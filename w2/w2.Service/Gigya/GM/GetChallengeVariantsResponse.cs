using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class GetChallengeVariantsResponse : BaseResponse
    {
        [JsonProperty("variants")]
        public Variant[] Variants { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

    }
}
