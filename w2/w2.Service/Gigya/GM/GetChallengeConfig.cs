using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class GetChallengeConfig : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.getChallengeConfig";
            }
        }

        [JsonProperty("includeChallenges")]
        public string IncludeChallenges { get; set; }

        [JsonProperty("excludeChallenges")]
        public string ExcludeChallenges { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("expandActions")]
        public bool ExpandActions { get; set; }

        [JsonProperty("includeDisabledChallenges")]
        public bool IncludeDisabledChallenges { get; set; }

        [JsonProperty("includeDisabledActions")]
        public bool IncludeDisabledActions { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public string HttpStatusCodes { get; set; }


    }
}
