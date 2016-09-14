using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class LevelResponse
    {
        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("badgeURL")]
        public string BadgeURL { get; set; }

        [JsonProperty("lockedBadgeURL")]
        public string LockedBadgeURL { get; set; }

        [JsonProperty("actionURL")]
        public string ActionURL { get; set; }

        [JsonProperty("bonus")]
        public int Bonus { get; set; }

        [JsonProperty("requiredActions")]
        public RequiredAction[] RequiredActions { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
