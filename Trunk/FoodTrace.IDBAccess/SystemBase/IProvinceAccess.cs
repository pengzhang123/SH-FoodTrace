using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IProvinceAccess : IBaseAccess<ProvinceModel>
    {
        int GetEntityCount(int? areaId, string name);

        List<ProvinceModel> GetPagerProvinceByConditions(int? areaId, string name, int pageIndex, int pageSize);
    }
}
