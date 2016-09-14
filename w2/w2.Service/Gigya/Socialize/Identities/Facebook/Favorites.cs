using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace w2.Service.Gigya.Socialize.Identities.Facebook
{
    public class Favorites : BaseRequest
    {
        [JsonProperty("interests")]
        public Interest Interests { get; set; }

        [JsonProperty("activities")]
        public Activity Activities { get; set; }

        [JsonProperty("books")]
        public object[] Books { get; set; }

        [JsonProperty("music")]
        public Music Music { get; set; }

        [JsonProperty("movies")]
        public Movy Movies { get; set; }

        [JsonProperty("television")]
        public Television Television { get; set; }
    }
}
