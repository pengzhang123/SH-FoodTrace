using FoodTrace.IDBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;
using FoodTrace.DBManage.IContexts;

namespace FoodTrace.DBAccess
{
    public class UserRoleAccess : BaseAccess, IUserRoleAccess
    {
        public MessageModel InsertSingleEntity(UserRoleModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.UserRole.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 根据用户id 获取角色列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserRoleModel> GetUserRefRoleByUid(int id)
        {
            return base.Context.UserRole.Where(s => s.UserID == id).ToList();
        }

    }
}
