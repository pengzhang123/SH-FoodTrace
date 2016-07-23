using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ICityAccess : IBaseAccess<CityModel>
    {
        int GetEntityCount(int? provinceId, string name);

        List<CityModel> GetPagerCityByConditions(int? provinceId, string name, int pageIndex, int pageSize);
    }
}
