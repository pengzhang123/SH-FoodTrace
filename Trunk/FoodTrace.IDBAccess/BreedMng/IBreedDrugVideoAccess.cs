using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedDrugVideoAccess : IBaseAccess<BreedDrugVideoModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedDrugVideoModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}

