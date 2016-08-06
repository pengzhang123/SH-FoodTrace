using System.Web;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Common.Libraries
{
    public class UserManagement
    {
        public UserManagement()
        {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session["UserBase"] != null)
                    {
                        CurrentUser = (UserSessionDto)HttpContext.Current.Session["UserBase"];
                    }
                }
        }
        public  static UserSessionDto CurrentUser { get; set; }

        public static CompanyModel CurrentCompany
        {
            get;
            set;
        }
    }
}
