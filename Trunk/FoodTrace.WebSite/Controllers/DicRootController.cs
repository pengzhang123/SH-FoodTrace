using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class DicRootController : BaseController
    {
        // GET: DicRoot
        public ActionResult Index()
        {
            return View();
        }
    }
}