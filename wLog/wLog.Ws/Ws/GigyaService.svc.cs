using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wLog.DB;
using wLog.Service;
using wLog.Ws.Interfaces;

namespace wLog.Ws.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GigyaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GigyaService.svc or GigyaService.svc.cs at the Solution Explorer and start debugging.
    public class GigyaService : IGigyaService
    {
        public void Log(string Response)
        {
            srvGigyaLogs srv = new srvGigyaLogs();
            GigyaLogs logs = ParseJsonObject<GigyaLogs>(Response);
            srv.Save(logs);
        }
        public static T ParseJsonObject<T>(string json) where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }
    }
}
