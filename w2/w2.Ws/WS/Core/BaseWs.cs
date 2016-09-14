using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ServiceModel.Activation;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using w2.Ws.Models;
using w2.Service.Gigya;
using w2.DB;
using w2.Service;

namespace w2.Ws
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BaseWs
    {
        protected T ParseJsonObject<T>(string json) where T : class, new()
        {
            JObject jObject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jObject.ToString());
        }

        private IDictionary<string, string> CollectionToDictionary(NameValueCollection source)
        {
            return source.AllKeys.ToDictionary(k => k, k => source[k]);
        }

        private string ParamsToJson()
        {
            var args = CollectionToDictionary(HttpContext.Current.Request.QueryString);
            var json = new JavaScriptSerializer().Serialize(args);
            return json;
        }

        protected T ConvertParamsToEnt<T>() where T : class, new()
        {
            var json = ParamsToJson();
            return ParseJsonObject<T>(json);
        }

        protected void RestCompability<T>(ref T ent) where T : class, new()
        {
            try
            {
                if (HttpContext.Current.Request["paramObject"] != null)
                {
                    var json = HttpContext.Current.Request["param"].ToString();
                    ent = ParseJsonObject<T>(json);
                }
                else if (HttpContext.Current.Request.QueryString.Count > 0)
                    ent = ConvertParamsToEnt<T>();
            }
            catch (System.Exception)
            {
                //Error Logs 
            }
        }


        protected void Compability<T>(ref T ent) where T : class, new()
        {
            if (ent == null)
            {
                if (HttpContext.Current.Request["paramObject"] != null)
                {
                    var json = HttpContext.Current.Request["param"].ToString();
                    ent = ParseJsonObject<T>(json);
                }
                else if (HttpContext.Current.Request.QueryString.Count > 0)
                    ent = ConvertParamsToEnt<T>();
            }
        }

        protected T Compability<T>() where T : class, new()
        {
            if (HttpContext.Current.Request["paramObject"] != null)
            {
                var json = HttpContext.Current.Request["param"].ToString();
                return ParseJsonObject<T>(json);
            }
            else if (HttpContext.Current.Request.QueryString.Count > 0)
                return ConvertParamsToEnt<T>();

            return null;
        }


        protected void PrintJson(object Obj)
        {
            HttpContext.Current.Response.ContentType = "application/json";
             HttpContext.Current.Response.Write(JsonConvert.SerializeObject(Obj));
        }

        protected void Log(VendorLogs log)
        {
            srvVendorLogs srv = new srvVendorLogs();
            srv.Save(log);
            
        }

    }
}