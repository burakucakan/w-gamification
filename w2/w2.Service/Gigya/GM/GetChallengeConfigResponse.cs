using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class GetChallengeConfigResponse : BaseResponse
    {
        [JsonProperty("challenges")]
        public Challenge[] Challenges { get; set; }

        [JsonProperty("actions")]
        public ActionResponse[] Actions { get; set; }


    }
}
