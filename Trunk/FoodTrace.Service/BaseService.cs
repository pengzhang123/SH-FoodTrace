using FoodTrace.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    public class BaseService
    {
        private const string AssemblyName = "FoodTrace.DBAccess";
        private static T CreateAccess<T>(string name)
        {
            try
            {
                return (T)Assembly.Load(AssemblyName).CreateInstance(CommonConfig.ReadConfigValue(name));
            }
            catch (Exception ex)
            {
                Common.Log.Logger.Error(ex);
                return default(T);
            }
        }

    }
}
