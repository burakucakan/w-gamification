using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.GM
{
    public partial class RedeemPoints : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.redeemPoints";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }

    }

      public partial class RedeemPoints
      {

        [DataMember]
        [JsonProperty("uid")]
        public string UID { get; set; }

        [DataMember]
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        [DataMember]
        [JsonProperty("points")]
        public int Points { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        //[DataMember]
        //[JsonProperty("ActionAttributes")]
        //public JsonObjectAttribute actionAttributes { get; set; }

        [DataMember]
        [JsonProperty("ActionAttributes")]
        public string actionAttributes { get; set; }

        [DataMember]
        [JsonProperty("variantID")]
        public string VariantID { get; set; }

  
    }
}
