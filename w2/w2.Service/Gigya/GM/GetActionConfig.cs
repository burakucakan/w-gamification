using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class GetActionConfig : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.getActionConfig";
            }
        }

        [JsonProperty("includeActions")]
        public string IncludeActions { get; set; }

        [JsonProperty("excludeActions")]
        public string ExcludeActions { get; set; }

        [JsonProperty("excludeActions")]
        public string Lang { get; set; }

        [JsonProperty("includeDisabledActions")]
        public string IncludeDisabledActions { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }
    }
}
