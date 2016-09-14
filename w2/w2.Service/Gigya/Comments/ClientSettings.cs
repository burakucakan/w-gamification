using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class ClientSettings
    {
        [JsonProperty("useSiteLogin")]
        public bool UseSiteLogin { get; set; }

        [JsonProperty("shareToSNCheckboxChecked")]
        public bool ShareToSNCheckboxChecked { get; set; }

        [JsonProperty("enableFBComments")]
        public bool EnableFBComments { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("newCommentPosition")]
        public string NewCommentPosition { get; set; }

        [JsonProperty("disableRSS")]
        public bool DisableRSS { get; set; }

        [JsonProperty("disableCommentsCount")]
        public bool DisableCommentsCount { get; set; }

        [JsonProperty("repliesCollapsed")]
        public bool RepliesCollapsed { get; set; }

        [JsonProperty("displayPosNegVotes")]
        public bool DisplayPosNegVotes { get; set; }

        [JsonProperty("refreshMode")]
        public string RefreshMode { get; set; }

        [JsonProperty("refreshInterval")]
        public int RefreshInterval { get; set; }

        [JsonProperty("maxCommentLength")]
        public int MaxCommentLength { get; set; }

        [JsonProperty("enableRichTextEditing")]
        public bool EnableRichTextEditing { get; set; }

        [JsonProperty("enableUserTagging")]
        public bool EnableUserTagging { get; set; }

        [JsonProperty("enableUserSorting")]
        public bool EnableUserSorting { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
