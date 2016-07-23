using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ITidAccess : IBaseAccess<TIDModel>
    {
        int GetEntityCount(string name);
        TIDModel GetEntityByChipCode(string code);
        List<TIDModel> GetPagerTidByConditions(int pageIndex, int pageSize);
    }
}
