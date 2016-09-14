using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class Challenge 
    {
        [JsonProperty("challengeID")]
        public string ChallengeID { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

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

        [JsonProperty("enableVariantTemplates")]
        public bool EnableVariantTemplates { get; set; }

        [JsonProperty("actions")]
        public string[] Actions { get; set; }

        [JsonProperty("challengeActions")]
        public ChallengeAction[] ChallengeActions { get; set; }

        [JsonProperty("levels")]
        public LevelResponse[] Levels { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
