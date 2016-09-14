using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public partial class SetUserOptions : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.setUserOptions";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class SetUserOptions
    {
        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("replyNotifications")]
        public string eRplyNotifications { get; set; }

        [DataMember]
        [JsonProperty("notificationsEmail")]
        public string NotificationsEmail { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
