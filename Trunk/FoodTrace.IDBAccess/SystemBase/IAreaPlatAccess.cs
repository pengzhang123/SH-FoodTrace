using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IAreaPlatAccess : IBaseAccess<AreaPlatModel>
    {
        int GetEntityCount(string name);

        List<AreaPlatModel> GetPagerAreaPlatByConditions(string name, int pageIndex, int pageSize);
    }
}
