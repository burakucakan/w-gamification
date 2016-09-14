using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class UserOptions
    {
        [JsonProperty("replyNotifications")]
        public string ReplyNotifications { get; set; }

        [JsonProperty("notificationsEmail")]
        public string NotificationsEmail { get; set; }

        [JsonProperty("notificationsLanguage")]
        public string NotificationsLanguage { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
