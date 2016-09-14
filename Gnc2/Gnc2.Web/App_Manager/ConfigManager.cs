using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIB.ExtentionMethods;
using System.Configuration;

namespace Gnc2.App_Manager
{
    public class ConfigManager
    {

        private static ConfigManager _ConfigManager;

        private ConfigManager() { }

        public static ConfigManager GetInstance()
        {
            if (_ConfigManager == null)
                _ConfigManager = new ConfigManager();
            return _ConfigManager;
        }

        private object GET(ConfigName ConfigName) { return ConfigurationManager.AppSettings[ConfigName.ToString()]; }
        public object GetManual(ConfigName ConfigName) { return ConfigurationManager.AppSettings[ConfigName.ToString()]; }

        public enum ConfigName
        {
            TurkcellSsoHeaderName,
            TestMsisdn,
            LocalSsoUrl,
            wsk,
            cid,
            appId

            /* Paths & Urls in Com.Helpers.UrlHelper */
        }

        public string TurkcellSsoHeaderName { get { return GET(ConfigName.TurkcellSsoHeaderName).ToString(); } }
        public string TestMsisdn { get { return GET(ConfigName.TestMsisdn).ToString(); } }
        public string LocalSsoUrl { get { return GET(ConfigName.LocalSsoUrl).ToString(); } }
        public string appId { get { return GET(ConfigName.appId).ToString(); } }
        public string wsk { get { return GET(ConfigName.wsk).ToString(); } }
        public string cid { get { return GET(ConfigName.cid).ToString(); } }
    }
}