using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class ChallengeAction
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("actionID")]
        public string ActionID { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("lifetimeCap")]
        public int LifetimeCap { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
