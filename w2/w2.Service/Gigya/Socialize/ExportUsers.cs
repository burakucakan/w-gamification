using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Socialize
{
    public class ExportUsers : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.exportUsers";
            }
        }


        [DataMember]
        [JsonProperty("fields")]
        public string Fields { get; set; }
        
        [DataMember]
        [JsonProperty("limit")]
        public int Limit { get; set; }
       
        [DataMember]
        [JsonProperty("includPendingUsers")]
        public bool IncludPendingUsers { get; set; }

    }
}
