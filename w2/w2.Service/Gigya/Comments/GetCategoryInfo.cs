using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Comments
{
    public class GetCategoryInfo : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "comments.getCategoryInfo";
            }
        }

        [DataMember]
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [DataMember]
        [JsonProperty("includeConfigSections")]
        public string IncludeConfigSections { get; set; }

        [DataMember]
        [JsonProperty("includeStreamCounts")]
        public bool IncludeStreamCounts { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
