﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class GetActionsLogResponse : BaseResponse
    {
        [JsonProperty("actions")]
        public ActionLogResponse Actions { get; set; }


    }
}
