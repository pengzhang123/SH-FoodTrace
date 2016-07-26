using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;
using FoodTrace.IDBAccess;
using FoodTrace.DBAccess;
using FoodTrace.IService;
using FoodTrace.Model.DtoModel;

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

        /// <summary>
        /// 登录用户获取用户相关信息
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public UserSessionDto GetUserLoginDto(string uid, string pwd)
        {
            return userLoginAccess.GetUserLoginDto(uid, pwd);
        }
    }
}
