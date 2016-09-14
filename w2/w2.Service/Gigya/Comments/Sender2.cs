using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class Sender2
    {
        [JsonProperty("photoURL")]
        public string PhotoURL { get; set; }

        [JsonProperty("profileURL")]
        public string ProfileURL { get; set; }

        [JsonProperty("loginProvider")]
        public string LoginProvider { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
