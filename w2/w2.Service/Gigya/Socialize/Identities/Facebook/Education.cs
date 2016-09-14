using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace w2.Service.Gigya.Socialize.Identities.Facebook
{
    public class Education : BaseRequest
    {
        [JsonProperty("school")]
        public string School { get; set; }

        [JsonProperty("schoolType")]
        public string SchoolType { get; set; }

        [JsonProperty("startYear")]
        public string StartYear { get; set; }
    }
}
