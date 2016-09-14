using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class Category
    {
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [JsonProperty("categorySettings")]
        public CategorySettings CategorySettings { get; set; }

        //[JsonProperty("clientSettings")]
        //public ClientSettings ClientSettings { get; set; }

        //[JsonProperty("streamSettings")]
        //public StreamSettings StreamSettings { get; set; }

        //[JsonProperty("ratingDims")]
        //public RatingDim[] RatingDims { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
