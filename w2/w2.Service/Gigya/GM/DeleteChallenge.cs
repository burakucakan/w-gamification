using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class DeleteChallenge : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.deleteChallenge";
            }
        }

        [JsonProperty("challengeID")]
        public string ChallengeID { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("httpStatusCodes")]
        public string HttpStatusCodes { get; set; }


    }
}
