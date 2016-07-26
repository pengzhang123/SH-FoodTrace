using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IUserRoleService
    {
        MessageModel InsertSingleEntity(UserRoleModel model);

        List<UserRoleModel> GetUserRefRoleByUid(int id);
    }
}
