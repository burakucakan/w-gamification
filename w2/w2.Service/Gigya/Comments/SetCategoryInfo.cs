using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class SetCategoryInfo : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.setCategoryInfo";
            }
        }
        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        //[JsonProperty("categorySettings")]
        //public JsonObjectAttribute CategorySettings { get; set; }

        //[JsonProperty("clientSettings")]
        //public JsonObjectAttribute ClientSettings { get; set; }

        //[JsonProperty("streamSettings")]
        //public JsonObjectAttribute StreamSettings { get; set; }

        //[JsonProperty("ratingDims")]
        //public object ratingDims { get; set; }

        [JsonProperty("ratingDims")]
        public string ratingDims { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
