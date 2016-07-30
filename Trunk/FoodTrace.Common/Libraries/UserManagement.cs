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
        public  static UserSessionDto CurrentUser
        {

            get
            {
                var userDto=new UserSessionDto(){ UserID = 1, UserName = "test", CompanyId= 1 };
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session["UserBase"] != null)
                    {
                        userDto = (UserSessionDto)HttpContext.Current.Session["UserBase"];
                    }
                }

                    return userDto;
            }
        }

        public static CompanyModel CurrentCompany
        {
            get;
            set;
        }
    }
}
