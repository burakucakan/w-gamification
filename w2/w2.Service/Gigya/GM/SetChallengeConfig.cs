using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using w2.Service.Gigya.GM.CustomObjects;

namespace w2.Service.Gigya.GM
{
    public class SetChallengeConfig : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.setChallengeConfig";
            }
        }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("enableTimeWindow")]
        public bool EnableTimeWindow { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("hideUntilFirstLevel")]
        public bool HideUntilFirstLevel { get; set; }

        [JsonProperty("hideUnlockedBadges")]
        public bool HideUnlockedBadges { get; set; }

        [JsonProperty("challengeActions")]
        public IEnumerable<ChallengeObj> ChallengeActions { get; set; }

        [JsonProperty("enableVariantTemplates")]
        public bool EnableVariantTemplates { get; set; }

        [JsonProperty("Levels")]
        public LevelRequest Levels { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }
    }
}
