using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IUserDetailService
    {
        /// <summary>
        /// 新增单条UserDetail
        /// </summary>
        /// <param name="model">UserDetail</param>
        /// <returns></returns>
        MessageModel InsertSingleUserBase(UserDetailModel model);
    }
}
