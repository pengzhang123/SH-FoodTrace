using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedHealthVideoAccess : IBaseAccess<BreedHealthVideoModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedHealthVideoModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
