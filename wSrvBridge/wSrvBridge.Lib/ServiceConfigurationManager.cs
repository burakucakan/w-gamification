using System;
using System.Configuration;

namespace wSrvBridge.Lib
{
    public sealed class ServiceConfigurationManager
    {
        private static PlatformType DefaultPlatform = PlatformType.Development;

        private static string ReadFromAppConfig(ConfigurationKeys configKey)
        {
            var configValue = ConfigurationManager.AppSettings[configKey.ToString()];
            return configValue == null ? null : configValue.ToString();
        }

        public static int PushInterval
        {
            get
            {
                return Convert.ToInt32(ReadFromAppConfig(ConfigurationKeys.PushInterval));
            }
        }

        public static int PermissionServiceId
        {
            get
            {
                return Convert.ToInt32(ReadFromAppConfig(ConfigurationKeys.PermissionServiceId));
            }
        }

        public static int PermissionServiceSourceId
        {
            get
            {
                return Convert.ToInt32(ReadFromAppConfig(ConfigurationKeys.PermissionServiceSourceId));
            }
        }

        public static string PennaUsername
        {
            get
            {
                return ReadFromAppConfig(ConfigurationKeys.PennaUsername);
            }
        }

        public static string PennaPassword
        {
            get
            {
                return ReadFromAppConfig(ConfigurationKeys.PennaPassword);
            }
        }

        public static PlatformType ActivePlatform
        {
            get
            {
                var activePlatformConfigValue = ReadFromAppConfig(ConfigurationKeys.Platform);
                if (activePlatformConfigValue == null)
                {
                    return DefaultPlatform;
                }

                return (PlatformType)Convert.ToInt32(activePlatformConfigValue);
            }
        }

        public static string ActiveDbConnection
        {
            get
            {
                var activeDbConfigValue = ReadFromAppConfig(ConfigurationKeys.ActiveDbConnection);
                return activeDbConfigValue;
            }
        }
    }
}
