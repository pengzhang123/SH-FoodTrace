using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ITrunDriverAccess : IBaseAccess<TrunDriverModel>
    {
        int GetEntityCount(int companyID, string name);
        List<TrunDriverModel> GetPagerTrunDriverByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
