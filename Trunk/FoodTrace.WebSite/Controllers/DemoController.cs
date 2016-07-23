using FoodTrace.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class DemoController : BaseController
    {
        ICompanyService companyService;
        public DemoController(ICompanyService cService)
        {
            companyService = cService;
        }

        // GET: Demo
        public ActionResult Index()
        {
            var count = companyService.GetCompanyCount();
            return View();
        }
    }
}