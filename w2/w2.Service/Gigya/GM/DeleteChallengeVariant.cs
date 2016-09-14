using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class DeleteChallengeVariant : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.deleteChallengeVariant";
            }
        }

        [JsonProperty("challengeID")]
        public string ChallengeID { get; set; }

        [JsonProperty("variantID")]
        public string VariantID { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }


    }
}
