using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IUserLoginAccess
    {
        MessageModel InsertSingleEntity(LogUserLoginModel model);
    }
}
