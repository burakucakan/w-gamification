﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Comments
{
    public class GetUserOptionsResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("userOptions")]
        public UserOptions UserOptions { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }
    }
}
