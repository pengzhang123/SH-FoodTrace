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
    public class UserDetailService : BaseService, IUserDetailService
    {
        private IUserDetailAccess userDetailAccess;
        
        public UserDetailService()
        {
            userDetailAccess = BaseAccess.CreateAccess<IUserDetailAccess>(AccessMappingKey.UserDetailAccess.ToString());
        }

        public MessageModel InsertSingleUserBase(UserDetailModel model)
        {
            return userDetailAccess.InsertSingleEntity(model);
        }
    }
}
