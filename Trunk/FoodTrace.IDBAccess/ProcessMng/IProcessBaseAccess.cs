using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IProcessBaseAccess : IBaseAccess<ProcessBaseModel>
    {
        int GetEntityCount(string name);
        List<ProcessBaseModel> GetPagerProcessBaseByConditions(string name, int pageIndex, int pageSize);
    }
}
