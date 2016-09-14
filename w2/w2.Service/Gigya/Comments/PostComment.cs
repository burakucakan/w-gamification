using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public partial class PostComment : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.postComment";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

    public partial class PostComment
    {

        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [DataMember]
        [JsonProperty("commentText")]
        public string CommentText { get; set; }

        [DataMember]
        [JsonProperty("streamID")]
        public string StreamID { get; set; }

        [DataMember]
        [JsonProperty("parentID")]
        public string ParentID { get; set; }

        [DataMember]
        [JsonProperty("guestName")]
        public string GuestName { get; set; }

        [DataMember]
        [JsonProperty("guestEmail")]
        public string GuestEmail { get; set; }

        [DataMember]
        [JsonProperty("cid")]
        public string CID { get; set; }

        [DataMember]
        [JsonProperty("tags")]
        public string Tags { get; set; }

        //[JsonProperty("actionAttributes")]
        //public JsonObjectAttribute ActionAttributes { get; set; }

        [DataMember]
        [JsonProperty("streamTags")]
        public string StreamTags { get; set; }


        /// <summary>
        /// Rating & Reviews related Parameters
        /// </summary>
        [DataMember]
        [JsonProperty("commentTitle")]
        public string CommentTitle { get; set; }

        [DataMember]
        [JsonProperty("ratings")]
        public string Ratings { get; set; }

        [DataMember]
        [JsonProperty("enabledProviders")]
        public string EnabledProviders { get; set; }

        [DataMember]
        [JsonProperty("disabledProviders")]
        public string DisabledProviders { get; set; }

        [DataMember]
        [JsonProperty("shortURLs")]
        public string ShortURLs { get; set; }

        [DataMember]
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [DataMember]
        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [DataMember]
        [JsonProperty("feedID")]
        public string FeedID { get; set; }

        
        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }


    }
}
