using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class DeleteAction : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.deleteAction";
            }
        }

        [JsonProperty("actionID")]
        public string ActionID { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }


    }
}
