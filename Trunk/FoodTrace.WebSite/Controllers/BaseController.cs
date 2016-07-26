using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    [AuthorizeFilter]
    public class BaseController : Controller
    {
        
    }
}