using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class ActionAttributes
    {
        [JsonProperty("glee")]
        public string[] Glee { get; set; }

        [JsonProperty("Code")]
        public string[] Code { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
