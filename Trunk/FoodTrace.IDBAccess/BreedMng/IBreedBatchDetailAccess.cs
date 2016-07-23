using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.IDBAccess
{
    public interface IBreedBatchDetailAccess : IBaseAccess<BreedBatchDetailModel>
    {
        int GetEntityCount(int companyID, string name);
        List<BreedBatchDetailModel> GetPagerBreedBatchDetailByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
