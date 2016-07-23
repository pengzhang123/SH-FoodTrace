using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class LogUserLoginController : BaseController
    {

        IUserBaseService iUserBaseService = new UserBaseService();
        IUserLoginService iUserLoginService = new UserLoginService();

        // GET: LogUserLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserBaseModel model)
        {
            var user = iUserBaseService.GetUserBase(model.UserName, model.Password);
            if(user == null)
            {
                return Json(new { success=false,msg= "No Such User" });
            }
            var result = iUserLoginService.InsertSingleEntity(new LogUserLoginModel { UserID = user.UserID, LoginTime = DateTime.Now, NickName=user.UserName });
            Session["UserBase"] = user;
            //Session["Role"] = user == null ? null : user.Role;

            return Json(new { success = true, msg = "Find the User" });
        }
    }
}