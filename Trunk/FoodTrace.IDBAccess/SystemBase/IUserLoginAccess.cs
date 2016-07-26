using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess
{
    public interface IUserLoginAccess
    {
        MessageModel InsertSingleEntity(LogUserLoginModel model);

        /// <summary>
        /// 登录用户获取用户相关信息
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        UserSessionDto GetUserLoginDto(string uid, string pwd);
    }
}
