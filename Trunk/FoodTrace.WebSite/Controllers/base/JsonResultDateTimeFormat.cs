using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FoodTrace.WebSite
{
    public class JsonResultDateTimeFormat:JsonResult
    {
        private const string Error = "该请求已被封锁，因为敏感信息透露给第三方网站，这是一个GET请求时使用的。为了可以GET请求，请设置JsonRequestBehavior AllowGet。";

        public JsonResultDateTimeFormat()
        {
            DateTimeFormateStr = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        public string DateTimeFormateStr
        {
            get;
            set;
        }

        /// <summary>
        /// 重写ExcuteResult类
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(Error);
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //string jsonstring = serializer.Serialize(Data);
                ////string p = @"\\/Date\((\d+)\+\d+\)\\/";
                //string p = @"\\/Date\(\d+\)\\/";
                //MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
                //Regex reg = new Regex(p);
                //jsonstring = reg.Replace(jsonstring, matchEvaluator);
                //response.Write(jsonstring);

                IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
                timeFormat.DateTimeFormat = this.DateTimeFormateStr; ;
                response.Write(JsonConvert.SerializeObject(this.Data,Formatting.Indented, timeFormat));
            }
        }


        /// <summary>
        /// 将Json序列化的时间由/Date(1294499956278+0800)转为字符串
        /// </summary>
        private string ConvertJsonDateToDateString(Match m)
        {

            string result = string.Empty;

            string p = @"\d";
            var cArray = m.Value.ToCharArray();
            StringBuilder sb = new StringBuilder();

            Regex reg = new Regex(p);
            for (int i = 0; i < cArray.Length; i++)
            {
                if (reg.IsMatch(cArray[i].ToString()))
                {
                    sb.Append(cArray[i]);
                }
            }
            // reg.Replace(m.Value;

            DateTime dt = new DateTime(1970, 1, 1);

            dt = dt.AddMilliseconds(long.Parse(sb.ToString()));

            dt = dt.ToLocalTime();

            result = dt.ToString("yyyy-MM-dd HH:mm:ss");

            return result;

        }
    }
}
