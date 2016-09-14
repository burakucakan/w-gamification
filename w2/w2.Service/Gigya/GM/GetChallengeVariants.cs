using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class GetChallengeVariants : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.getChallengeVariants";
            }
        }

        [JsonProperty("challengeID")]
        public string ChallengeID { get; set; }

        [JsonProperty("variantID")]
        public string VariantID { get; set; }

        //Edit
        [JsonProperty("actionAttributes")]
        public string ActionAttributes { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }


    }
}
