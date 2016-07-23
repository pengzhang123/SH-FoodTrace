using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    public class UserRoleService : BaseService, IUserRoleService
    {
        private IUserRoleAccess userRoleIndexAccess;
        public UserRoleService()
        {
            userRoleIndexAccess = BaseAccess.CreateAccess<IUserRoleAccess>(AccessMappingKey.UserRoleAccess.ToString());
        }

        public MessageModel InsertSingleEntity(UserRoleModel model)
        {
            return userRoleIndexAccess.InsertSingleEntity(model);
        }
    }
}
