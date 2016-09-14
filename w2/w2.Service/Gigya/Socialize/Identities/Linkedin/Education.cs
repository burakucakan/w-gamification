using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace w2.Service.Gigya.Socialize.Identities.Linkedin
{
    public class Education : BaseRequest
    {
        [JsonProperty("school")]
        public string School { get; set; }

        [JsonProperty("schoolType")]
        public string SchoolType { get; set; }

        [JsonProperty("startYear")]
        public string StartYear { get; set; }

        [JsonProperty("fieldOfStudy")]
        public string FieldOfStudy { get; set; }

        [JsonProperty("degree")]
        public string Degree { get; set; }

        [JsonProperty("endYear")]
        public string EndYear { get; set; }
    }
}
