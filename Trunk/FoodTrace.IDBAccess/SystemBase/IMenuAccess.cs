using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IMenuAccess : IBaseAccess<MenuModel>
    {
        int GetEntityCount(string name);

        List<MenuModel> GetPagerMenuByConditions(string name, int pageIndex, int pageSize);
    }
}
