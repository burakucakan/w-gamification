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
    public partial class Logout : BaseRequest
    {
        public override string Method
        {
            get
            {
                return "socialize.logout";
            }
        }

        [DataMember]
        public string Msisdn
        {
            get { return String.IsNullOrEmpty(UID) ? String.Empty : LIB.Encryption.Decrypt(UID); }
            set { UID = LIB.Encryption.Encrypt(value); }
        }
    }

    public partial class Logout : BaseRequest
    {
        [JsonProperty("uID")]
        public string UID { get; set; }


        [DataMember]
        [JsonProperty("cid")]
        public string Cid { get; set; }

        [DataMember]
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [DataMember]
        [JsonProperty("httpStatusCodes")]
        public bool HttpStatusCodes { get; set; }

    }
}
