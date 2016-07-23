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
    }
}
