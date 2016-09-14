﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace w2.Service.Gigya.GM
{
    public class SetGlobalConfig : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "gm.setGlobalConfig";
            }
        }

        [JsonProperty("callbackURL")]
        public string CallbackURL { get; set; }

        [JsonProperty("allowClientSideNotifyAction")]
        public bool AllowClientSideNotifyAction { get; set; }


    }
}
