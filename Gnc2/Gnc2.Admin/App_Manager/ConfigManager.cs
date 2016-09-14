using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using LIB.ExtentionMethods;

namespace Gnc2.Admin.App_Manager
{
    public class ConfigManager
    {
        #region Structure

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
        #endregion

        public enum ConfigName
        {
            /* Paths & Urls in Com.Helpers.UrlHelper */
            AutoLogin,
            AdminId,
            IsContentMultiLanguageEnabled,
            UploadDefaultMaxKB,
            url_Static
        }

        public bool AutoLogin { get { return Convert.ToBoolean(GET(ConfigName.AutoLogin).ToString()); } }
        public string AdminId { get { return (string)GET(ConfigName.AdminId); } }
        public string url_Static { get { return (string)GET(ConfigName.url_Static); } }
        public bool IsContentMultiLanguageEnabled { get { return Convert.ToBoolean(GET(ConfigName.IsContentMultiLanguageEnabled).ToString()); } }
        public int UploadDefaultMaxKB { get { return GET(ConfigName.UploadDefaultMaxKB).ToInt(); } }
    }
}