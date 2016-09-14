using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class StreamSettings
    {
        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("threadingDepth")]
        public int ThreadingDepth { get; set; }

        [JsonProperty("sortBy")]
        public string SortBy { get; set; }

        [JsonProperty("allowNegativeVoting")]
        public bool AllowNegativeVoting { get; set; }

        [JsonProperty("allowGuest")]
        public bool AllowGuest { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("enableCommentTitles")]
        public string EnableCommentTitles { get; set; }

        [JsonProperty("enableCommentBody")]
        public string EnableCommentBody { get; set; }

        [JsonProperty("allowCommentDeletion")]
        public bool AllowCommentDeletion { get; set; }

        [JsonProperty("isGuestEmailRequired")]
        public bool IsGuestEmailRequired { get; set; }

        [JsonProperty("enableFlagging")]
        public bool EnableFlagging { get; set; }

        [JsonProperty("enableRatings")]
        public string EnableRatings { get; set; }

        [JsonProperty("flaggingEmailAfter")]
        public int FlaggingEmailAfter { get; set; }

        [JsonProperty("flaggingPendingAfter")]
        public int FlaggingPendingAfter { get; set; }

        [JsonProperty("moderationState")]
        public int ModerationState { get; set; }

        [JsonProperty("enableVoting")]
        public bool EnableVoting { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
