using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ICountryAccess : IBaseAccess<CountryModel>
    {
        int GetEntityCount(int? cityId, string name);
        List<CountryModel> GetPagerCountryByConditions(int? cityId, string name, int pageIndex, int pageSize);
    }
}
