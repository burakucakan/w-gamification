using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class RequiredAction
    {
        [JsonProperty("actionID")]
        public string ActionID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
