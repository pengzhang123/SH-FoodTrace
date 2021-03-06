﻿using FoodTrace.Common;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.DtoModel;
using FoodTrace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class LogUserLoginController : Controller
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
           // var user = iUserBaseService.GetUserBase(model.UserName, model.Password);
            string pwd = EncodeStrToMd5.String32ToMD5(model.Password);
            var user = iUserLoginService.GetUserLoginDto(model.UserName, pwd);
            if(user == null)
            {
                return Json(new { success=false,msg= "用户名或密码错误" });
            }
            var result = iUserLoginService.InsertSingleEntity(new LogUserLoginModel { UserID = user.UserID, LoginTime = DateTime.Now, NickName=user.UserName });
            Session["UserBase"] = user;
            //Session["Role"] = user == null ? null : user.Role;
 
             UserManagement.CurrentUser =user;

            return Json(new { success = true, msg = "Find the User" });
        }
    }
}