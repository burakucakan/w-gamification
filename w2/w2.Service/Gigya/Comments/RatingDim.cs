﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class RatingDim 
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
