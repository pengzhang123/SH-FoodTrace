using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Common.Libraries
{
    public class CommonConfig
    {
        #region
        public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["EntityContext"].ToString(); } }
        #endregion

        #region
        public static string ReadConfigValue(string key)
        {
            return ReadConfigValue(key, string.Empty);
        }

        public static string ReadConfigValue(string key, string defaultValue)
        {
            string configValue;
            try
            {
                configValue = ConfigurationManager.AppSettings[key];
                if (configValue == null)
                    configValue = defaultValue;
            }
            catch
            {
                configValue = defaultValue;
            }
            return configValue;
        }
        #endregion
    }
}
