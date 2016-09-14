using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class ActionResponse
    {
        [JsonProperty("actionID")]
        public string ActionID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("dailyCap")]
        public int DailyCap { get; set; }

        [JsonProperty("freqCap")]
        public int FreqCap { get; set; }

        [JsonProperty("triggeringActionId")]
        public string TriggeringActionId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
