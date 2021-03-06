﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Socialize
{
    public class GetUserSettingsResponse : BaseResponse
    {
       
        [DataMember]
        [JsonProperty("settings")]
        public string Settings { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
