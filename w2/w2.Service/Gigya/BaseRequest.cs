using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using w2.Service.Gigya;
namespace w2.Service.Gigya
{
    [DataContract]
    public class BaseRequest
    {
        [GigyaParameter(IsRequired = false)]
        [DataMember]
        public virtual string Key { get; set; }

        /// <summary>
        /// Default Parameter
        /// </summary>
        [JsonProperty("apiKey")]
        public virtual string ApiKey { get; set; }

        /// <summary>
        /// Default Parameter
        /// </summary>
        [JsonProperty("secret")]
        public virtual string SecretKey { get; set; }

        /// <summary>
        /// Default Parameter
        /// </summary>
        [JsonProperty("format")]
        public virtual string Format { get { return w2.Com.Config.App.Format; } }

        /// <summary>
        /// Default Parameter
        /// </summary>
        [JsonProperty("method")]
        [DataMember]
        public virtual string Method { get; set; }
    }
}
