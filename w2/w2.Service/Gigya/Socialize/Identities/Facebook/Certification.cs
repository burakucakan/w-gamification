﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace w2.Service.Gigya.Socialize.Identities.Facebook
{
    public class Certification : BaseRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
