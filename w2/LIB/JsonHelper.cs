using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LIB
{
    public class JsonHelper
    {
        public static T ParseJsonObject<T>(string json) where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }
        public static T ParseJObject<T>(object obj) where T : class, new()
        {
            JObject jobject = JObject.FromObject(obj);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }

    }
}