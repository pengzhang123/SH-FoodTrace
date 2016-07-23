using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.DBAccess
{
    public class UserLoginAccess:BaseAccess, IUserLoginAccess
    {
        public MessageModel InsertSingleEntity(LogUserLoginModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.LogUserLogin.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }
    }
}
