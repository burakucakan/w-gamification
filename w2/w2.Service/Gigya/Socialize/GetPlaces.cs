using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Socialize
{
    public class GetPlaces : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.getPlaces";
            }
        }

        [DataMember]
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [DataMember]
        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [DataMember]
        [JsonProperty("query")]
        public string Query { get; set; }

        [DataMember]
        [JsonProperty("radius")]
        public int Radius { get; set; }

        [DataMember]
        [JsonProperty("unifyResults")]
        public bool UnifyResults { get; set; }

        [DataMember]
        [JsonProperty("enabledProviders")]
        public string EnabledProviders { get; set; }

        [DataMember]
        [JsonProperty("disabledProviders")]
        public string DisabledProviders { get; set; }

        [DataMember]
        [JsonProperty("cid")]
        public string CID { get; set; }

        [DataMember]
        [JsonProperty("context")]
        public string Context { get; set; }

    }
}
