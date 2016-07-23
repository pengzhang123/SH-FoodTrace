using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedMaterialVideoAccess : IBaseAccess<BreedMaterialVideoModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedMaterialVideoModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
