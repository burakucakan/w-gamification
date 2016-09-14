using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    [DataContract]
    public class Achievement
    {
        [DataMember]
        [JsonProperty("challengeID")]
        public string ChallengeID { get; set; }

        [DataMember]
        [JsonProperty("level")]
        public int Level { get; set; }

        [DataMember]
        [JsonProperty("isNewLevel")]
        public bool IsNewLevel { get; set; }

        [DataMember]
        [JsonProperty("pointsTotal")]
        public int PointsTotal { get; set; }

        [DataMember]
        [JsonProperty("points7Days")]
        public int Points7Days { get; set; }

        [DataMember]
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [DataMember]
        [JsonProperty("rank7Days")]
        public int Rank7Days { get; set; }

        [DataMember]
        [JsonProperty("badgeURL")]
        public string BadgeURL { get; set; }

        [DataMember]
        [JsonProperty("levelTitle")]
        public string LevelTitle { get; set; }

        [DataMember]
        [JsonProperty("levelDescription")]
        public string LevelDescription { get; set; }

        [DataMember]
        [JsonProperty("challengeTitle")]
        public string ChallengeTitle { get; set; }

        [DataMember]
        [JsonProperty("challengeDescription")]
        public string ChallengeDescription { get; set; }

        [DataMember]
        [JsonProperty("pointsCurrent")]
        public int PointsCurrent { get; set; }

        [DataMember]
        [JsonProperty("achievementsToNextLevel")]
        public int AchievementsToNextLevel { get; set; }

        [DataMember]
        [JsonProperty("requiredAchievement")]
        public string RequiredAchievement { get; set; }

        [DataMember]
        [JsonProperty("nextLevelTitle")]
        public string NextLevelTitle { get; set; }

        [DataMember]
        [JsonProperty("nextLevelDescription")]
        public string NextLevelDescription { get; set; }

        [DataMember]
        [JsonProperty("nextLevelLockedBadgeURL")]
        public string NextLevelLockedBadgeURL { get; set; }

        [DataMember]
        [JsonProperty("nextLevelActionURL")]
        public string NextLevelActionURL { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
