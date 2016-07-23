using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface ISeedBaseAccess : IBaseAccess<SeedBaseModel>
    {
        int GetEntityCount(string name);

        List<SeedBaseModel> GetPagerSeedBaseByConditions(string name, int pageIndex, int pageSize);
    }
}
