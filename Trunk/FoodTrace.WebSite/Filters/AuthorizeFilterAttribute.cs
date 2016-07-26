using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FoodTrace.Model;
using FoodTrace.Model.DtoModel;


namespace FoodTrace.WebSite
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

             //获取访问路径
             var path = filterContext.HttpContext.Request.Path.ToLower();

            //判断用户Session是否超时
            UserSessionDto userSession = filterContext.HttpContext.Session["UserBase"] as UserSessionDto;
            if (userSession == null && path!="/home/index")
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }

           
            
        }

        /// <summary>
        /// 判断该请求是否为ajax请求
        /// </summary>
        /// <param name="requestBase"></param>
        /// <returns></returns>
        public bool VaildateIsAjaxRequest(HttpRequestBase requestBase)
        {
            return requestBase.IsAjaxRequest();
        }
        /// <summary>
        /// 验证访问的Url是否有权限
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool ValidateRequestUrl(string url)
        {
            bool isValidated = false;
            //try
            //{
            //    var permValidate = new PermissionValidate();
            //    isValidated=permValidate.VailidateRequestUrl(url);
            //    //验证方法
            //}
            //catch (Exception ex)
            //{
                
            //    log4netHelper.Exception(ex);
            //}

            return isValidated;
        }
    }
}
