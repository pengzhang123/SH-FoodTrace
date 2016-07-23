using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;
using FoodTrace.IDBAccess;
using FoodTrace.DBAccess;
using FoodTrace.IService;

namespace FoodTrace.Service
{
    public class UserLoginService : BaseService, IUserLoginService
    {
        private IUserLoginAccess userLoginAccess;
        public UserLoginService()
        {
            userLoginAccess = BaseAccess.CreateAccess<IUserLoginAccess>(AccessMappingKey.UserLoginAccess.ToString());
        }

        public MessageModel InsertSingleEntity(LogUserLoginModel model)
        {
            return userLoginAccess.InsertSingleEntity(model);
        }
    }
}
