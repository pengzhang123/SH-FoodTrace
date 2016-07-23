using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IRoleAccess:IBaseAccess<RoleModel>
    {
        int GetEntityCount(string name);

        List<RoleModel> GetPagerRoleByConditions(string name, int pageIndex, int pageSize);

        MessageModel InsertSingleEntity(RoleModel roleModel, List<RoleMenuModel> roleMenuModel);
    }
}
