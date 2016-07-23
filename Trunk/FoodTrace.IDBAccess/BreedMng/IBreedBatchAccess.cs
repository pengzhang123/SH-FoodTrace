using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedBatchAccess : IBaseAccess<BreedBatchModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedBatchModel> GetPagerBreedBatchByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
