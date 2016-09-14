using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class CategorySettings
    {
        [JsonProperty("useAkismet")]
        public bool UseAkismet { get; set; }

        [JsonProperty("publishToGoogleActivityStream")]
        public bool PublishToGoogleActivityStream { get; set; }

        [JsonProperty("newCommentNotificationEnabled")]
        public bool NewCommentNotificationEnabled { get; set; }

        [JsonProperty("moderatorEditComment")]
        public bool ModeratorEditComment { get; set; }

        //[JsonProperty("blockedWords")]
        //public object[] BlockedWords { get; set; }

        [JsonProperty("blockedWords")]
        public string BlockedWords { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
