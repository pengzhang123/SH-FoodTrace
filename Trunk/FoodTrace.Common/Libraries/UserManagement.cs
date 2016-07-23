using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Common.Libraries
{
    public class UserManagement
    {
        public static UserBaseModel CurrentUser
        {
            get { return new UserBaseModel() { UserID = 1, UserName = "test", CompanyID=1 }; }
        }

        public static CompanyModel CurrentCompany
        {
            get;
            set;
        }
    }
}
