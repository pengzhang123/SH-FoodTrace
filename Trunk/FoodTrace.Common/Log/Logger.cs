using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Common.Log
{
    public class Logger
    {
        private static ILog info = LogManager.GetLogger("INFO");
        private static ILog error = LogManager.GetLogger("error");
        private static ILog debug = LogManager.GetLogger("debug");
        
        /// <summary>
        /// FATAL登录写入文件
        /// </summary>
        /// <param name="pEx">异常信息</param>
        public static void Error(string pMsg)
        {
            error.Error(pMsg);
        }

        /// <summary>
        /// FATAL登录写入文件
        /// </summary>
        /// <param name="pEx">异常信息</param>
        public static void Error(Exception pEx)
        {
            error.Error(pEx.Message, pEx);
        }

        /// <summary>
        /// error登录写入文件
        /// </summary>
        /// <param name="pEx">异常信息</param>
        public static void Error(string pMsg, Exception pEx)
        {
            error.Error(pMsg, pEx);
        }

        /// <summary>
        /// info登录写入文件
        /// </summary>
        /// <param name="pEx">异常信息</param>
        public static void Info(string pMsg)
        {
            info.Info(pMsg);
        }

        /// <summary>
        /// info登录写入文件
        /// </summary>
        /// <param name="pEx">异常信息</param>
        public static void Info(Exception pEx)
        {
            info.Info(pEx.Message, pEx);
        }

        /// <summary>
        /// 调试Log写入
        /// </summary>
        public static void Debug(string pMsg)
        {
            debug.Debug(pMsg);
        }

        /// <summary>
        /// 调试Log写入
        /// </summary>
        public static void Debug(Exception pEx)
        {
            debug.Debug(pEx.Message, pEx);
        }
    }
}
