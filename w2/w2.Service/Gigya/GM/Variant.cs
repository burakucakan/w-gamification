using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class Variant
    {
        [JsonProperty("variantID")]
        public string VariantID { get; set; }

        [JsonProperty("actionAttributes")]
        public ActionAttributes ActionAttributes { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
