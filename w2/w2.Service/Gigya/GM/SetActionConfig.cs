using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class SetActionConfig : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.setActionConfig";
            }
        }

        [JsonProperty("actionID")]
        public string ActionID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("freqCap")]
        public int FreqCap { get; set; }

        [JsonProperty("dailyCap")]
        public int DailyCap { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("triggerActionID")]
        public string TriggerActionID { get; set; }

        [JsonProperty("allowClientSideNotifyAction")]
        public bool AllowClientSideNotifyAction { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }


    }
}
