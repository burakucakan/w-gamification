using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace w2.Service.Gigya.Socialize.Identities.Facebook
{
    public class Work : BaseRequest
    {
        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("companyID")]
        public string CompanyID { get; set; }
    }
}
