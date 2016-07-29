using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    [AuthorizeFilter]
    public class BaseController : Controller
    {
        protected virtual JsonResult JsonEx(object data, string dateTimeFormatStr = "yyyy-MM-dd HH:mm:ss")
        {
            return new JsonResultDateTimeFormat()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                DateTimeFormateStr = dateTimeFormatStr,
                ContentEncoding = Encoding.UTF8,
                ContentType = "text/plain",
            };
        }
    }
}