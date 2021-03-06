﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace w2.Service.Gigya.Comments
{
    public class GetCategoryInfoResponse : BaseResponse
    {
        [DataMember]
        [JsonProperty("category")]
        public Category Category { get; set; }

        [GigyaParameter(IsRequired = false)]
        [JsonProperty("Key")]
        public string Key { get; set; }

        
    }
}
